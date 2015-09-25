﻿using System.Threading.Tasks;
using apcurium.MK.Booking.Api.Contract.Requests;
using apcurium.MK.Booking.Api.Contract.Resources;
using apcurium.MK.Booking.Mobile.Infrastructure;
using CMTPayment.Extensions;

namespace apcurium.MK.Booking.Api.Client.TaxiHail
{
	public class FlightInformationServiceClient : BaseServiceClient
	{
		public FlightInformationServiceClient(string url, string sessionId, IPackageInfo packageInfo)
            : base(url, sessionId, packageInfo)
        {
        }
		public Task<FlightInformation> GetTerminal(FlightInformationRequest request)
		{
			return Client.PostAsync(request);
		}
	}
}