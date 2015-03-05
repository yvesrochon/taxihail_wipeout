using System.Collections.Generic;
using System.Threading.Tasks;
using apcurium.MK.Booking.Api.Contract.Resources;

namespace apcurium.MK.Booking.Mobile.AppServices
{
    public interface INetworkRoamingService
    {
        Task<string> GetCompanyMarket(double latitude, double longitude);

        Task<List<NetworkFleet>> GetNetworkFleets();
    }
}