using System;
using apcurium.MK.Booking.Api.Contract.Resources;
using apcurium.MK.Booking.Mobile.Data;

namespace apcurium.MK.Booking.Mobile.Infrastructure
{
	public interface IAppContext
	{
        AccountData LoggedUser { get; }
						
	}
}

