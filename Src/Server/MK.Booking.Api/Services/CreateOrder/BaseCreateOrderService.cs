﻿using System;
using System.Linq;
using System.Net;
using apcurium.MK.Booking.Api.Contract.Resources;
using apcurium.MK.Booking.Api.Helpers.CreateOrder;
using apcurium.MK.Booking.Commands;
using apcurium.MK.Booking.Domain;
using apcurium.MK.Booking.IBS;
using apcurium.MK.Booking.ReadModel;
using apcurium.MK.Booking.ReadModel.Query.Contract;
using apcurium.MK.Booking.Services;
using apcurium.MK.Common;
using apcurium.MK.Common.Configuration;
using apcurium.MK.Common.Entity;
using apcurium.MK.Common.Enumeration;
using apcurium.MK.Common.Extensions;
using Infrastructure.EventSourcing;
using Infrastructure.Messaging;
using ServiceStack.Common.Web;
using ServiceStack.ServiceInterface;

namespace apcurium.MK.Booking.Api.Services.CreateOrder
{
    public class BaseCreateOrderService : Service
    {
        private readonly IServerSettings _serverSettings;
        private readonly ICommandBus _commandBus;
        private readonly IAccountChargeDao _accountChargeDao;
        private readonly IPaymentService _paymentService;
        private readonly ICreditCardDao _creditCardDao;
        private readonly IIBSServiceProvider _ibsServiceProvider;
        private readonly IPromotionDao _promotionDao;
        private readonly IEventSourcedRepository<Promotion> _promoRepository;
        private readonly IAccountDao _accountDao;
        private readonly IPayPalServiceFactory _payPalServiceFactory;

        private readonly Resources.Resources _resources;

        protected readonly CreateOrderPaymentHelper PaymentHelper;

        internal BaseCreateOrderService(IServerSettings serverSettings,
            ICommandBus commandBus,
            IAccountChargeDao accountChargeDao,
            IPaymentService paymentService,
            ICreditCardDao creditCardDao,
            IIBSServiceProvider ibsServiceProvider,
            IPromotionDao promotionDao,
            IEventSourcedRepository<Promotion> promoRepository,
            IOrderPaymentDao orderPaymentDao,
            IAccountDao accountDao,
            IPayPalServiceFactory payPalServiceFactory)
        {
            _serverSettings = serverSettings;
            _commandBus = commandBus;
            _accountChargeDao = accountChargeDao;
            _paymentService = paymentService;
            _creditCardDao = creditCardDao;
            _ibsServiceProvider = ibsServiceProvider;
            _promotionDao = promotionDao;
            _promoRepository = promoRepository;
            _accountDao = accountDao;
            _payPalServiceFactory = payPalServiceFactory;
            _resources = new Resources.Resources(_serverSettings);

            PaymentHelper = new CreateOrderPaymentHelper(serverSettings, commandBus, paymentService, orderPaymentDao, payPalServiceFactory);
        }

        protected internal void ValidateAppVersion(string clientLanguage, CreateReportOrder createReportOrder)
        {
            var appVersion = base.Request.Headers.Get("ClientVersion");
            var minimumAppVersion = _serverSettings.ServerData.MinimumRequiredAppVersion;

            if (appVersion.IsNullOrEmpty() || minimumAppVersion.IsNullOrEmpty())
            {
                return;
            }

            var minimumMajorMinorBuild = minimumAppVersion.Split(new[] { "." }, StringSplitOptions.RemoveEmptyEntries);
            var appMajorMinorBuild = appVersion.Split('.');

            for (var i = 0; i < appMajorMinorBuild.Length; i++)
            {
                var appVersionItem = int.Parse(appMajorMinorBuild[i]);
                var minimumVersionItem = int.Parse(minimumMajorMinorBuild.Length <= i ? "0" : minimumMajorMinorBuild[i]);

                if (appVersionItem < minimumVersionItem)
                {
                    Exception createOrderException = new HttpError(HttpStatusCode.BadRequest, ErrorCode.CreateOrder_RuleDisable.ToString(),
                                        _resources.Get("CannotCreateOrderInvalidVersion", clientLanguage));

                    createReportOrder.Error = createOrderException.ToString();
                    _commandBus.Send(createReportOrder);
                    throw createOrderException;
                }
            }
        }

        protected ChargeAccountValidationResult ValidateChargeAccountIfNecessary(string companyKey, Contract.Requests.CreateOrder request, Guid orderId, AccountDetail account, bool isFutureBooking, bool isFromWebApp, decimal bookingFees, CreateReportOrder createReportOrder)
        {
            string[] prompts = null;
            int?[] promptsLength = null;
            string chargeTypeOverride = null;
            var isChargeAccountPaymentWithCardOnFile = false;

            if (request.Settings.ChargeTypeId.HasValue
                && request.Settings.ChargeTypeId.Value == ChargeTypes.Account.Id)
            {
                var accountChargeDetail = _accountChargeDao.FindByAccountNumber(request.Settings.AccountNumber);

                if (accountChargeDetail.UseCardOnFileForPayment)
                {
                    if (isFromWebApp)
                    {
                        // Charge account cannot support prepaid orders
                        Exception createOrderException = new HttpError(HttpStatusCode.BadRequest, ErrorCode.CreateOrder_RuleDisable.ToString(),
                            _resources.Get("CannotCreateOrderChargeAccountNotSupportedOnWeb", request.ClientLanguageCode));

                        createReportOrder.Error = createOrderException.ToString();
                        _commandBus.Send(createReportOrder);
                        throw createOrderException;
                    }

                    if (_paymentService.IsPayPal(account.Id))
                    {
                        chargeTypeOverride = ChargeTypes.PayPal.Display;
                        request.Settings.ChargeTypeId = ChargeTypes.PayPal.Id;
                    }
                    else
                    {
                        chargeTypeOverride = ChargeTypes.CardOnFile.Display;
                        request.Settings.ChargeTypeId = ChargeTypes.CardOnFile.Id;
                    }

                    isChargeAccountPaymentWithCardOnFile = true;
                }

                ValidateChargeAccountAnswers(request.Settings.AccountNumber, request.Settings.CustomerNumber, request.QuestionsAndAnswers, request.ClientLanguageCode, createReportOrder);

                if (isChargeAccountPaymentWithCardOnFile)
                {
                    ValidatePayment(companyKey, request, orderId, account, isFutureBooking, request.Estimate.Price, bookingFees, false, createReportOrder);
                }

                prompts = request.QuestionsAndAnswers.Select(q => q.Answer).ToArray();
                promptsLength = request.QuestionsAndAnswers.Select(q => q.MaxLength).ToArray();
            }

            return new ChargeAccountValidationResult
            {
                Prompts = prompts,
                PromptsLength = promptsLength,
                ChargeTypeKeyOverride = chargeTypeOverride,
                IsChargeAccountPaymentWithCardOnFile = isChargeAccountPaymentWithCardOnFile
            };
        }

        protected void ValidateChargeAccountAnswers(string accountNumber, string customerNumber, AccountChargeQuestion[] userQuestionsDetails, string clientLanguageCode, CreateReportOrder createReportOrder)
        {
            var accountChargeDetail = _accountChargeDao.FindByAccountNumber(accountNumber);
            if (accountChargeDetail == null)
            {
                var createOrderException = new HttpError(HttpStatusCode.BadRequest,
                    ErrorCode.AccountCharge_InvalidAccountNumber.ToString(),
                    GetCreateOrderServiceErrorMessage(ErrorCode.AccountCharge_InvalidAccountNumber, clientLanguageCode));

                createReportOrder.Error = createOrderException.ToString();
                _commandBus.Send(createReportOrder);
                throw createOrderException;
            }

            var answers = userQuestionsDetails.Select(x => x.Answer);

            var validation = _ibsServiceProvider.ChargeAccount().ValidateIbsChargeAccount(answers, accountNumber, customerNumber);
            if (!validation.Valid)
            {
                if (validation.ValidResponse != null)
                {
                    int firstError = validation.ValidResponse.IndexOf(false);
                    var invalidAnswerException = new HttpError(HttpStatusCode.BadRequest, ErrorCode.AccountCharge_InvalidAnswer.ToString(),
                                            accountChargeDetail.Questions[firstError].ErrorMessage);

                    createReportOrder.Error = invalidAnswerException.ToString();
                    _commandBus.Send(createReportOrder);
                    throw invalidAnswerException;
                }

                var invalidAccountException = new HttpError(HttpStatusCode.BadRequest, ErrorCode.AccountCharge_InvalidAccountNumber.ToString(), validation.Message);

                createReportOrder.Error = invalidAccountException.ToString();
                _commandBus.Send(createReportOrder);
                throw invalidAccountException;
            }
        }

        protected void ValidatePayment(string companyKey, Contract.Requests.CreateOrder request, Guid orderId, AccountDetail account, bool isFutureBooking, double? appEstimate, decimal bookingFees, bool isPrepaid, CreateReportOrder createReportOrder)
        {
            var tipPercent = account.DefaultTipPercent ?? _serverSettings.ServerData.DefaultTipPercentage;

            // If there's an estimate, add tip to that estimate
            if (appEstimate.HasValue)
            {
                appEstimate = appEstimate.Value + FareHelper.CalculateTipAmount(appEstimate.Value, tipPercent);
            }

            var appEstimateWithTip = appEstimate.HasValue ? Convert.ToDecimal(appEstimate.Value) : (decimal?)null;

            if (isPrepaid)
            {
                // Verify that prepaid is enabled on the server
                if (!_serverSettings.GetPaymentSettings(companyKey).IsPrepaidEnabled)
                {
                    var createOrderException = new HttpError(HttpStatusCode.BadRequest,
                        ErrorCode.CreateOrder_RuleDisable.ToString(),
                         _resources.Get("CannotCreateOrder_PrepaidButPrepaidNotEnabled", request.ClientLanguageCode));

                    createReportOrder.Error = createOrderException.ToString();
                    _commandBus.Send(createReportOrder);
                    throw createOrderException;
                }

                // PayPal is handled elsewhere since it has a different behavior

                // Payment mode is CardOnFile
                if (request.Settings.ChargeTypeId.HasValue
                    && request.Settings.ChargeTypeId.Value == ChargeTypes.CardOnFile.Id)
                {
                    if (!appEstimateWithTip.HasValue)
                    {
                        var createOrderException = new HttpError(HttpStatusCode.BadRequest,
                            ErrorCode.CreateOrder_RuleDisable.ToString(),
                            _resources.Get("CannotCreateOrder_PrepaidNoEstimate", request.ClientLanguageCode));

                        createReportOrder.Error = createOrderException.ToString();
                        _commandBus.Send(createReportOrder);
                        throw createOrderException;
                    }

                    ValidateCreditCard(account, request.ClientLanguageCode, request.Cvv, createReportOrder);

                    var result = PaymentHelper.CapturePaymentForPrepaidOrder(companyKey, orderId, account, Convert.ToDecimal(appEstimateWithTip), tipPercent, bookingFees, request.Cvv, createReportOrder);
                    if (!result.IsSuccessful)
                    {
                        var createOrderException = new HttpError(HttpStatusCode.BadRequest, ErrorCode.CreateOrder_RuleDisable.ToString(), result.Message);

                        createReportOrder.Error = createOrderException.ToString();
                        _commandBus.Send(createReportOrder);

                        throw createOrderException;
                    }
                }
            }
            else
            {
                // Payment mode is CardOnFile
                if (request.Settings.ChargeTypeId.HasValue
                    && request.Settings.ChargeTypeId.Value == ChargeTypes.CardOnFile.Id)
                {
                    ValidateCreditCard(account, request.ClientLanguageCode, request.Cvv, createReportOrder);

                    var isSuccessful = PaymentHelper.PreAuthorizePaymentMethod(companyKey, orderId, account,
                        request.ClientLanguageCode, isFutureBooking, appEstimateWithTip, bookingFees,
                        false, createReportOrder, request.Cvv);

                    if (!isSuccessful)
                    {
                        var errorMessage = _resources.Get("CannotCreateOrder_CreditCardWasDeclined", request.ClientLanguageCode);
                        var createOrderException = new HttpError(HttpStatusCode.BadRequest, ErrorCode.CreateOrder_RuleDisable.ToString(), errorMessage);

                        createReportOrder.Error = createOrderException.ToString();
                        _commandBus.Send(createReportOrder);

                        throw createOrderException;
                    }
                }

                // Payment mode is PayPal
                if (request.Settings.ChargeTypeId.HasValue
                    && request.Settings.ChargeTypeId.Value == ChargeTypes.PayPal.Id)
                {
                    ValidatePayPal(companyKey, orderId, account, request.ClientLanguageCode, isFutureBooking, appEstimateWithTip, bookingFees, createReportOrder);
                }
            }
        }

        protected void ValidateCreditCard(AccountDetail account, string clientLanguageCode, string cvv, CreateReportOrder createReportOrder)
        {
            // check if the account has a credit card
            if (!account.DefaultCreditCard.HasValue)
            {
                var createOrderException = new HttpError(HttpStatusCode.BadRequest,
                    ErrorCode.CreateOrder_CardOnFileButNoCreditCard.ToString(),
                    GetCreateOrderServiceErrorMessage(ErrorCode.CreateOrder_CardOnFileButNoCreditCard, clientLanguageCode));

                createReportOrder.Error = createOrderException.ToString();
                _commandBus.Send(createReportOrder);
                throw createOrderException;
            }

            var creditCard = _creditCardDao.FindByAccountId(account.Id).First();
            if (creditCard.IsExpired())
            {
                var createOrderException = new HttpError(HttpStatusCode.BadRequest,
                    ErrorCode.CreateOrder_RuleDisable.ToString(),
                     _resources.Get("CannotCreateOrder_CreditCardExpired", clientLanguageCode));

                createReportOrder.Error = createOrderException.ToString();
                _commandBus.Send(createReportOrder);
                throw createOrderException;
            }
            if (creditCard.IsDeactivated)
            {
                var createOrderException = new HttpError(HttpStatusCode.BadRequest,
                    ErrorCode.CreateOrder_CardOnFileDeactivated.ToString(),
                    _resources.Get("CannotCreateOrder_CreditCardDeactivated", clientLanguageCode));

                createReportOrder.Error = createOrderException.ToString();
                _commandBus.Send(createReportOrder);
                throw createOrderException;
            }

            if (_serverSettings.GetPaymentSettings().AskForCVVAtBooking
                && !cvv.HasValue())
            {
                var createOrderException = new HttpError(HttpStatusCode.BadRequest,
                    ErrorCode.CreateOrder_RuleDisable.ToString(),
                     _resources.Get("CannotCreateOrder_CreditCardCvvRequired", clientLanguageCode));

                createReportOrder.Error = createOrderException.ToString();
                _commandBus.Send(createReportOrder);
                throw createOrderException;
            }
        }

        private void ValidatePayPal(string companyKey, Guid orderId, AccountDetail account, string clientLanguageCode, bool isFutureBooking, decimal? appEstimateWithTip, decimal bookingFees, CreateReportOrder createReportOrder)
        {
            if (!_serverSettings.GetPaymentSettings(companyKey).PayPalClientSettings.IsEnabled
                    || !account.IsPayPalAccountLinked)
            {
                var createOrderException = new HttpError(HttpStatusCode.BadRequest,
                    ErrorCode.CreateOrder_RuleDisable.ToString(),
                     _resources.Get("CannotCreateOrder_PayPalButNoPayPal", clientLanguageCode));

                createReportOrder.Error = createOrderException.ToString();
                _commandBus.Send(createReportOrder);
                throw createOrderException;
            }

            var isSuccessful = PaymentHelper.PreAuthorizePaymentMethod(companyKey, orderId, account, clientLanguageCode, isFutureBooking, appEstimateWithTip, bookingFees, true, createReportOrder);
            if (!isSuccessful)
            {
                var errorMessage = _resources.Get("CannotCreateOrder_PayPalWasDeclined", clientLanguageCode);
                var createOrderException = new HttpError(HttpStatusCode.BadRequest, ErrorCode.CreateOrder_RuleDisable.ToString(), errorMessage);

                createReportOrder.Error = createOrderException.ToString();
                _commandBus.Send(createReportOrder);

                throw createOrderException;
            }
        }

        protected Guid? ValidatePromotion(string companyKey, string promoCode, int? chargeTypeId, Guid accountId, DateTime pickupDate, bool isFutureBooking, string clientLanguageCode, CreateReportOrder createReportOrder)
        {
            if (!promoCode.HasValue())
            {
                // No promo code entered
                return null;
            }

            var usingPaymentInApp = chargeTypeId == ChargeTypes.CardOnFile.Id || chargeTypeId == ChargeTypes.PayPal.Id;
            if (!usingPaymentInApp)
            {
                var payPalIsEnabled = _serverSettings.GetPaymentSettings(companyKey).PayPalClientSettings.IsEnabled;
                var cardOnFileIsEnabled = _serverSettings.GetPaymentSettings(companyKey).IsPayInTaxiEnabled;

                var promotionErrorResourceKey = "CannotCreateOrder_PromotionMustUseCardOnFile";
                if (payPalIsEnabled && cardOnFileIsEnabled)
                {
                    promotionErrorResourceKey = "CannotCreateOrder_PromotionMustUseCardOnFileOrPayPal";
                }
                else if (payPalIsEnabled)
                {
                    promotionErrorResourceKey = "CannotCreateOrder_PromotionMustUsePayPal";
                }

                // Should never happen since we will check client-side if there's a promocode and not paying with CoF/PayPal
                var createOrderException = new HttpError(HttpStatusCode.BadRequest, ErrorCode.CreateOrder_RuleDisable.ToString(),
                    _resources.Get(promotionErrorResourceKey, clientLanguageCode));

                createReportOrder.Error = createOrderException.ToString();
                _commandBus.Send(createReportOrder);
                throw createOrderException;
            }

            var promo = _promotionDao.FindByPromoCode(promoCode);
            if (promo == null)
            {
                Exception createOrderException = new HttpError(HttpStatusCode.BadRequest, ErrorCode.CreateOrder_RuleDisable.ToString(),
                    _resources.Get("CannotCreateOrder_PromotionDoesNotExist", clientLanguageCode));

                createReportOrder.Error = createOrderException.ToString();
                _commandBus.Send(createReportOrder);
                throw createOrderException;
            }

            var promoDomainObject = _promoRepository.Get(promo.Id);
            string errorMessage;
            if (!promoDomainObject.CanApply(accountId, pickupDate, isFutureBooking, out errorMessage))
            {
                var createOrderException = new HttpError(HttpStatusCode.BadRequest, ErrorCode.CreateOrder_RuleDisable.ToString(),
                    _resources.Get(errorMessage, clientLanguageCode));

                createReportOrder.Error = createOrderException.ToString();
                _commandBus.Send(createReportOrder);
                throw createOrderException;
            }

            return promo.Id;
        }

        protected void ValidateProvider(Contract.Requests.CreateOrder request, ReferenceData referenceData, bool isInExternalMarket, CreateReportOrder createReportOrder)
        {
            // Provider is optional for home market
            // But if a provider is specified, it must match with one of the ReferenceData values
            if (!isInExternalMarket
                && request.Settings.ProviderId.HasValue
                && referenceData.CompaniesList.None(c => c.Id == request.Settings.ProviderId.Value))
            {

                var createOrderException = new HttpError(HttpStatusCode.BadRequest,
                    ErrorCode.CreateOrder_InvalidProvider.ToString(),
                    GetCreateOrderServiceErrorMessage(ErrorCode.CreateOrder_InvalidProvider, request.ClientLanguageCode));

                if (createReportOrder != null)
                {
                    createReportOrder.Error = createOrderException.ToString();
                    _commandBus.Send(createReportOrder);
                }
                throw createOrderException;
            }
        }

        protected string GetCreateOrderServiceErrorMessage(ErrorCode errorCode, string language)
        {
            var callMessage = string.Format(_resources.Get("ServiceError" + errorCode, language),
                _serverSettings.ServerData.TaxiHail.ApplicationName,
                _serverSettings.ServerData.DefaultPhoneNumberDisplay);

            var noCallMessage = _resources.Get("ServiceError" + errorCode + "_NoCall", language);

            return _serverSettings.ServerData.HideCallDispatchButton ? noCallMessage : callMessage;
        }

        protected int CreateIbsAccountIfNeeded(AccountDetail account, string companyKey = null)
        {
            var ibsAccountId = _accountDao.GetIbsAccountId(account.Id, companyKey);
            if (ibsAccountId.HasValue)
            {
                return ibsAccountId.Value;
            }

            // Account doesn't exist, create it
            ibsAccountId = _ibsServiceProvider.Account(companyKey).CreateAccount(account.Id,
                account.Email,
                string.Empty,
                account.Name,
                account.Settings.Phone);

            _commandBus.Send(new LinkAccountToIbs
            {
                AccountId = account.Id,
                IbsAccountId = ibsAccountId.Value,
                CompanyKey = companyKey
            });

            return ibsAccountId.Value;
        }

        protected CreateReportOrder CreateReportOrder(Contract.Requests.CreateOrder request, AccountDetail account)
        {
            return new CreateReportOrder
            {
                PickupDate = request.PickupDate ?? DateTime.Now,
                UserNote = request.Note,
                PickupAddress = request.PickupAddress,
                DropOffAddress = request.DropOffAddress,
                Settings = request.Settings,
                ClientLanguageCode = request.ClientLanguageCode,
                UserLatitude = request.UserLatitude,
                UserLongitude = request.UserLongitude,
                CompanyKey = request.OrderCompanyKey,
                AccountId = account.Id,
                OrderId = request.Id,
                EstimatedFare = request.Estimate.Price,
                UserAgent = Request.UserAgent,
                ClientVersion = Request.Headers.Get("ClientVersion"),
                TipIncentive = request.TipIncentive
            };
        }
    }
}
