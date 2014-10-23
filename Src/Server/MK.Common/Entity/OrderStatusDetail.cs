#region

using System;

#endregion

namespace apcurium.MK.Common.Entity
{
    public class OrderStatusDetail
    {
        public OrderStatusDetail()
        {
            DriverInfos = new DriverInfos();
        }

        public OrderStatus Status { get; set; }
        public DriverInfos DriverInfos { get; set; }
        public int? IBSOrderId { get; set; }
        public string IBSStatusId { get; set; }
        public string IBSStatusDescription { get; set; }
        public string VehicleNumber { get; set; }
        public double? VehicleLatitude { get; set; }
        public double? VehicleLongitude { get; set; }
        public bool FareAvailable { get; set; }
        public Guid OrderId { get; set; }
        public Guid AccountId { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime? Eta { get; set; }
        public string Name { get; set; }
        public string ReferenceNumber { get; set; }
        public string TerminalId { get; set; }
        public bool IsTaxiNearbyNotificationSent { get; set; }
        public DateTime? PairingTimeOut { get; set; }
        public string PairingError { get; set; }

        public string CompanyKey { get; set; }
        public string RequestedCompanyKey { get; set; }
        public DateTime? NetworkParingTimeout { get; set; }
        public double? UserLatitude { get; set; }
        public double? UserLongitude { get; set; }


        public override string ToString()
        {
            return Status + " " + Name;
        }
    }
}