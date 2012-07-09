
using System;
using System.Collections.Generic;

using System.Linq;

using apcurium.Framework.Extensions;

namespace apcurium.MK.Booking.Mobile.Data
{
	public class AccountData
	{
		public AccountData ()
		{
			BookingHistory = new BookingInfoData[0];
			FavoriteLocations = new LocationData[0];
		}
		
		
		public BookingInfoData AddNewHistory()
		{
			List<BookingInfoData> list = new List<BookingInfoData>();
			if ( BookingHistory != null &&  BookingHistory.Count() > 0 )
			{
				list.AddRange( BookingHistory );
			}
			
			var result = new BookingInfoData();
			list.Add( result );
			
			BookingHistory = list.ToArray();
			
			return result;
		}
		
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }

		public BookingSetting DefaultSettings { get; set; }

		public BookingInfoData[] BookingHistory { get; set; }

		public LocationData[] FavoriteLocations { get; set; }

		public void AddBooking (BookingInfoData data)
		{
			var list = new List<BookingInfoData> ();
			if ((BookingHistory != null) && (BookingHistory.Count () > 0)) {
				list.AddRange (BookingHistory);
			}
			
			list.Add (data);
			
			BookingHistory = list.ToArray ();
		}

		public string FacebookId { get; set; }
		public string TwitterId { get; set; }
	
	}
}

