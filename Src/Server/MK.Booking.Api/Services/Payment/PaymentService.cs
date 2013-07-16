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
            _commandBus.Send(new UpdatePaymentSettings()
                {
                    ServerPaymentSettings = request.ServerPaymentSettings,
                });
        }
        public TestServerPaymentSettingsResponse Post(TestServerPaymentSettingsRequest request)
        {
            var response = new TestServerPaymentSettingsResponse()
                {
                    IsSuccessful = false,
                    Message = ""
                };

            try
            {
                if (!PayPalService.TestClient(_configurationManager, RequestContext, request.ServerPaymentSettings.PayPalServerSettings.SandboxCredentials, true))
                 {
                     response.IsSuccessful = false;
                     response.Message += "Paypal Sandbox Credentials are invalid\n"; 
                 }
                if (!PayPalService.TestClient(_configurationManager, RequestContext, request.ServerPaymentSettings.PayPalServerSettings.Credentials, false))
                 {
                     response.IsSuccessful = false;
                     response.Message += "Paypal Production Credentials are invalid\n";
                 }
            }
            catch (Exception)
            {
                response.IsSuccessful = false;
                response.Message += "Paypal Credentials are invalid\n";
            }

            switch (request.ServerPaymentSettings.PaymentMode)
            {
                case PaymentMethod.Braintree:
                    try
                    {
                        if (!BraintreePaymentService.TestClient(request.ServerPaymentSettings.BraintreeServerSettings))
                        {
                            response.IsSuccessful = false;
                            response.Message += "Brain Tree Settings are Invalid\n";
                        }
                    }
                    catch (Exception)
                    {
                        response.IsSuccessful = false;
                        response.Message += "Brain Tree Settings are Invalid\n";
                    }
                    break;
                case PaymentMethod.Cmt:
                               
                    try
                    {
                        if (!CmtPaymentClient.TestClient(request.ServerPaymentSettings.CmtPaymentSettings))
                        {
                            response.IsSuccessful = false;
                            response.Message += "CMT Settings are Invalid\n";
                        }
                    }
                    catch (Exception)
                    {
                        response.IsSuccessful = false;
                        response.Message += "CMT Settings are Invalid\n";
                    }
                    break;
            }
            if (response.IsSuccessful)
            {
                response.Message = "Settings are Vaild";
            }
            return response;
        }
    }
}
