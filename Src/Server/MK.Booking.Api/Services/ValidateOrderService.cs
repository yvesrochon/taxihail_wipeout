﻿#region

using System;
using apcurium.MK.Booking.Api.Contract.Requests;
using apcurium.MK.Booking.Api.Contract.Resources;
using apcurium.MK.Booking.Calculator;
using apcurium.MK.Booking.IBS;
using apcurium.MK.Common.Configuration;
using apcurium.MK.Common.Extensions;
using CustomerPortal.Client.Impl;
using log4net;
using ServiceStack.ServiceInterface;

#endregion

namespace apcurium.MK.Booking.Api.Services
{
    public class ValidateOrderService : Service
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (ValidateOrderService));

        private readonly IServerSettings _serverSettings;
        private readonly IRuleCalculator _ruleCalculator;
        private readonly TaxiHailNetworkServiceClient _taxiHailNetworkServiceClient;
        private readonly IIBSServiceProvider _ibsServiceProvider;

        public ValidateOrderService(
            IServerSettings serverSettings,
            IIBSServiceProvider ibsServiceProvider,
            IRuleCalculator ruleCalculator,
            TaxiHailNetworkServiceClient taxiHailNetworkServiceClient)
        {
            _serverSettings = serverSettings;
            _ibsServiceProvider = ibsServiceProvider;
            _ruleCalculator = ruleCalculator;
            _taxiHailNetworkServiceClient = taxiHailNetworkServiceClient;
        }

        public object Post(ValidateOrderRequest request)
        {
            Func<string> getPickupZone =
                () => request.TestZone.HasValue() ? request.TestZone : _ibsServiceProvider.StaticData().GetZoneByCoordinate(request.Settings.ProviderId,
                    request.PickupAddress.Latitude, request.PickupAddress.Longitude);

            Func<string> getDropoffZone =
                () =>
                    request.DropOffAddress != null
                        ? _ibsServiceProvider.StaticData().GetZoneByCoordinate(request.Settings.ProviderId,
                            request.DropOffAddress.Latitude, request.DropOffAddress.Longitude)
                        : null;

            string market = null;

            try
            {
                // Find market
                market = _taxiHailNetworkServiceClient.GetCompanyMarket(request.PickupAddress.Latitude, request.PickupAddress.Longitude);
            }
            catch (Exception ex)
            {
                Log.Info("Unable to fetch market");
                Log.Error(ex);
            }

            if (request.ForError)
            {
                var rule = _ruleCalculator.GetActiveDisableFor(request.PickupDate.HasValue,
                                        request.PickupDate ?? GetCurrentOffsetedTime(),
                                        getPickupZone, getDropoffZone, market);

                string message = null;
                var hasError = false;
                var disableFutureBooking = false;

                if (rule != null && rule.AppliesToFutureBooking && rule.DisableFutureBookingOnError)
                {
                    disableFutureBooking = true;
                }
                else
                {
                    hasError = rule != null;
                    message = rule != null ? rule.Message : null;
                }

                Log.Debug(string.Format("Has Error : {0}, Message: {1}", hasError, message));

                return new OrderValidationResult
                {
                    HasError = hasError,
                    Message = message,
                    DisableFutureBooking = disableFutureBooking
                };
            }
            else
            {
                var rule = _ruleCalculator.GetActiveWarningFor(request.PickupDate.HasValue,
                                        request.PickupDate ?? GetCurrentOffsetedTime(),
                                        getPickupZone, getDropoffZone, market);

                var disableFutureBooking = rule != null && rule.AppliesToFutureBooking && rule.DisableFutureBookingOnError;

                return new OrderValidationResult
                {
                    HasWarning = rule != null,
                    Message = rule != null ? rule.Message : null,
                    DisableFutureBooking = disableFutureBooking
                };
            }
        }

        private DateTime GetCurrentOffsetedTime()
        {
            var ibsServerTimeDifference = _serverSettings.ServerData.IBS.TimeDifference;
            var offsetedTime = DateTime.Now.AddMinutes(2);
            if (ibsServerTimeDifference != 0)
            {
                offsetedTime = offsetedTime.Add(new TimeSpan(ibsServerTimeDifference));
            }

            return offsetedTime;
        }
    }
}