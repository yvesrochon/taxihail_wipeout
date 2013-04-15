﻿using System;

namespace apcurium.MK.Booking.IBS
{
    public interface IBookingWebServiceClient 
    {        
        int? CreateOrder(int? providerId, int accountId, string passengerName, string phone, int nbPassengers, int? vehicleTypeId, int? chargeTypeId, string note, DateTime pickupDateTime, IBSAddress pickup, IBSAddress dropoff);

        IBSOrderStatus GetOrderStatus(int orderId, int accountId, string contactPhone);    

        IBSOrderDetails GetOrderDetails(int orderId, int accountId, string contactPhone);

        bool CancelOrder(int orderId, int accountId, string contactPhone);

        bool SendMessageToDriver(string carId, string message);
    }
}