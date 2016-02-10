#region

using System.Threading.Tasks;
using apcurium.MK.Common;
using apcurium.MK.Common.Diagnostic;

#if !CLIENT
using apcurium.MK.Booking.Api.Client.Extensions;
#endif
using apcurium.MK.Booking.Api.Contract.Resources;
using apcurium.MK.Booking.Mobile.Infrastructure;
using apcurium.MK.Common.Extensions;

#endregion

namespace apcurium.MK.Booking.Api.Client.TaxiHail
{
    public class ReferenceDataServiceClient : BaseServiceClient
    {
        public ReferenceDataServiceClient(string url, string sessionId, IPackageInfo packageInfo, IConnectivityService connectivityService, ILogger logger)
            : base(url, sessionId, packageInfo, connectivityService, logger)
        {
        }

        public Task<ReferenceData> GetReferenceData()
        {
            return Client.GetAsync<ReferenceData>("/referencedata", logger: Logger);
        }
    }
}