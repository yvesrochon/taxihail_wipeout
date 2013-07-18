﻿using System;
using System.Globalization;
using System.Net;
using Infrastructure.Messaging;
using ServiceStack.ServiceInterface;
using apcurium.MK.Booking.Api.Client;
using apcurium.MK.Booking.Api.Client.Cmt.Payments;
using apcurium.MK.Booking.Api.Contract.Requests.Payment;
using apcurium.MK.Booking.Api.Contract.Resources.Payments;
using apcurium.MK.Booking.Commands;
using apcurium.MK.Booking.IBS;
using apcurium.MK.Booking.ReadModel.Query.Contract;
using apcurium.MK.Common;
using apcurium.MK.Common.Configuration;
using apcurium.MK.Common.Configuration.Impl;

namespace apcurium.MK.Booking.Api.Services.Payment
{
    public class PaymentService : Service
    {
        private readonly ICommandBus _commandBus;
        private readonly IConfigurationDao _configurationDao;
        private readonly IConfigurationManager _configurationManager;

        public PaymentService(ICommandBus commandBus, IConfigurationDao configurationDao,IConfigurationManager configurationManager)
        {
            _commandBus = commandBus;
            _configurationDao = configurationDao;
            _configurationManager = configurationManager;
        }

        public PaymentSettingsResponse Get(PaymentSettingsRequest request)
        {
            return new PaymentSettingsResponse()
                {
                    ClientPaymentSettings = _configurationDao.GetPaymentSettings()
                };
        }

        public ServerPaymentSettingsResponse Get(ServerPaymentSettingsRequest request)
        {
            var settings = _configurationDao.GetPaymentSettings();
            return new ServerPaymentSettingsResponse()
            {
                ServerPaymentSettings = settings
            };
        }

        public void Post(UpdateServerPaymentSettingsRequest request)
        {
            if (request.ServerPaymentSettings.IsPayInTaxiEnabled &&
                request.ServerPaymentSettings.PaymentMode == PaymentMethod.None)
            {
                throw new ArgumentException("Please Select a payment setting");
            }
            _commandBus.Send(new UpdatePaymentSettings()
                {
                    ServerPaymentSettings = request.ServerPaymentSettings,
                });
        }


        public TestServerPaymentSettingsResponse Post(TestPayPalProductionSettingsRequest request)
        {
            var response = new TestServerPaymentSettingsResponse()
            {
                IsSuccessful = false,
                Message = "Paypal Production Credentials are invalid\n"
            };

            try
            {
                if (PayPalService.TestClient(_configurationManager, RequestContext, request.Credentials, false))
                {
                    return new TestServerPaymentSettingsResponse()
                        {
                            IsSuccessful = true,
                            Message = "Paypal Production Credentials are Valid\n"
                        };
                }
            
            }
            catch (Exception e)
            {
                response.Message += e.Message + "\n";
            }
            return response;
        }

        public TestServerPaymentSettingsResponse Post(TestPayPalSandboxSettingsRequest request)
        {
            var response = new TestServerPaymentSettingsResponse()
            {
                IsSuccessful = false,
                Message = "Paypal Sandbox Credentials are invalid\n"
            };

            try
            {
                if (PayPalService.TestClient(_configurationManager, RequestContext, request.Credentials, true))
                {
                    return new TestServerPaymentSettingsResponse()
                    {
                        IsSuccessful = true,
                        Message = "Paypal Sandbox Credentials are Valid\n"
                    };
                }

            }
            catch (Exception e)
            {
                response.Message += e.Message + "\n";
            }
            return response;
        }

        public TestServerPaymentSettingsResponse Post(TestBraintreeSettingsRequest request)
        {
            var response = new TestServerPaymentSettingsResponse()
                {
                    IsSuccessful = false,
                    Message = "Braintree Settings are Invalid\n"
                };
            
            try
            {
                if (BraintreePaymentService.TestClient(request.BraintreeServerSettings, request.BraintreeClientSettings))
                {
                 return new TestServerPaymentSettingsResponse()
                     {
                         IsSuccessful = true,
                         Message = "Braintree Settings are Valid\n"
                     };   
                }
            }
            catch (Exception e)
            {
                response.Message += e.Message + "\n";
            }

            return response;
        }

        public TestServerPaymentSettingsResponse Post(TestCmtSettingsRequest request)
        {
            var response = new TestServerPaymentSettingsResponse()
            {
                IsSuccessful = false,
                Message = "CMT Settings are Invalid\n"
            };

            try
            {

                var cc = new TestCreditCards(TestCreditCards.TestCreditCardSetting.Cmt).Visa;

                if (CmtPaymentClient.TestClient(request.CmtPaymentSettings, cc.Number, cc.ExpirationDate))
                {
                    return new TestServerPaymentSettingsResponse()
                        {
                            IsSuccessful = true,
                            Message = "CMT Settings are Valid\n"

                        };
                }
            }
            catch (Exception e)
            {
                response.Message += e.Message+"\n";
            }
           
            return response;
        }
    }
}
