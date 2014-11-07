﻿#region

using System;
using System.Collections.Generic;
using apcurium.MK.Common;
using apcurium.MK.Common.Entity;

#endregion

namespace apcurium.MK.Booking.IBS
{
    public interface IBookingWebServiceClient
    {
        int? CreateOrder(int? providerId, int accountId, string passengerName, string phone, int nbPassengers, int? vehicleTypeId, int? chargeTypeId, string note,
            DateTime pickupDateTime, IbsAddress pickup, IbsAddress dropoff, string accountNumber, int? customerNumber, Fare fare = default(Fare));

        IbsOrderStatus GetOrderStatus(int orderId, int accountId, string contactPhone);

        IbsOrderDetails GetOrderDetails(int orderId, int accountId, string contactPhone);
        
        IbsFareEstimate GetFareEstimate(double? pickupLat, double? pickupLng, double? dropoffLat, double? dropoffLng, string accountNumber, int? customerNumber, int? waitTime);

        bool CancelOrder(int orderId, int accountId, string contactPhone);

        IEnumerable<IBSOrderInformation> GetOrdersStatus(IList<int> ibsOrdersIds);

        bool SendMessageToDriver(string message, string vehicleNumber);

        IbsVehiclePosition[] GetAvailableVehicles(double latitude, double longitude, int? vehicleTypeId);

        bool ConfirmExternalPayment(Guid orderId, int ibsOrderId, decimal totalAmount, decimal tipAmount, decimal meterAmount, string type, string provider, string transactionId,
            string authorizationCode, string cardToken, int accountID, string name, string phone, string email, string os, string userAgent);
 
        int? SendAccountInformation(Guid orderId, int ibsOrderId, string type, string cardToken, int accountID, string name, string phone, string email);
   }
}