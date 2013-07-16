using System;
using Cirrious.MvvmCross.Interfaces.Commands;
using apcurium.MK.Booking.Mobile.AppServices.Impl;
using apcurium.MK.Booking.Mobile.Messages;
using TinyMessenger;
using TinyIoC;
using apcurium.MK.Booking.Mobile.Infrastructure;
using apcurium.MK.Booking.Api.Contract.Resources;
using ServiceStack.Text;
using System.Globalization;
using apcurium.MK.Common.Extensions;
using apcurium.MK.Common.Configuration.Impl;
using Cirrious.MvvmCross.Interfaces.ViewModels;
using apcurium.MK.Common.Entity;

namespace apcurium.MK.Booking.Mobile.ViewModels
{
	public class RideSummaryViewModel: BaseViewModel
	{
		public RideSummaryViewModel (string order, string orderStatus)
		{			
			Order = order.FromJson<Order> ();
			OrderStatus = orderStatus.FromJson<OrderStatusDetail>();
			IsRatingButtonShown = AppSettings.RatingEnabled;
		}

		public string ThankYouTitle {
			get{
				return Str.ThankYouTitle;
			}
		}

		public string ThankYouMessage {
			get{
				return Str.ThankYouMessage;
			}
		}


		private Order Order {get; set;}
		OrderStatusDetail OrderStatus{ get; set;}
		public bool IsPayButtonShown{
			get{
				var setting = ConfigurationManager.GetPaymentSettings ();
				var isPayEnabled = setting.IsPayInTaxiEnabled || setting.PayPalClientSettings.IsEnabled;
				return isPayEnabled;
			}
		}

		public bool IsSendReceiptButtonShown {
			get{
				var sendReceiptAvailable =  !ConfigurationManager.GetSetting("Client.SendReceiptAvailable").TryToParse(false);
				return (OrderStatus != null) && OrderStatus.FareAvailable && sendReceiptAvailable;
			}
		}

		bool _isRatingButtonShow;		
		public bool IsRatingButtonShown {
			get { 
				return _isRatingButtonShow;
			}
			set { 
				_isRatingButtonShow = value;
				FirePropertyChanged (() => IsRatingButtonShown);
			}
		}

		public IMvxCommand SendReceiptCommand {
			get {
				return new AsyncCommand (() =>
				{
					BookingService.SendReceipt (Order.Id);
				});
			}
		}

		public IMvxCommand NavigateToRatingPage {
			get {
				return new AsyncCommand (() =>
				{
					RequestSubNavigate<BookRatingViewModel, OrderRated> (new 
					{
						orderId = Order.Id.ToString (), 
						canRate = true.ToString (CultureInfo.InvariantCulture), 
						isFromStatus = true.ToString (CultureInfo.InvariantCulture)
					}.ToStringDictionary(),_=>{
						IsRatingButtonShown = false;
					});
				});
			}
		}

		public IMvxCommand PayCommand {
			get {
				return new AsyncCommand (() =>
				{
					RequestNavigate<ConfirmCarNumberViewModel>(
					new 
					{ 
						order = Order.ToJson(),
						orderStatus = OrderStatus.ToJson()
					}, false, MvxRequestedBy.UserAction);
				});
			}
		}




	}

}

