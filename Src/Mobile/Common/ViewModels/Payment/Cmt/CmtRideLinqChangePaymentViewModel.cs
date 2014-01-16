using System;
using apcurium.MK.Booking.Mobile.AppServices;
using apcurium.MK.Booking.Mobile.Extensions;
using ServiceStack.Text;
using System.Windows.Input;

namespace apcurium.MK.Booking.Mobile.ViewModels.Payment.Cmt
{
	public class CmtRideLinqChangePaymentViewModel : BaseSubViewModel<PaymentInformation>
	{
		public new void Init(string currentPaymentInformation)
		{
			DefaultPaymentInformations = JsonSerializer.DeserializeFromString<PaymentInformation>(currentPaymentInformation);
			PaymentPreferences = new PaymentDetailsViewModel();
			PaymentPreferences.Init(DefaultPaymentInformations);
			PaymentPreferences.LoadCreditCards();
		}

		public PaymentInformation DefaultPaymentInformations { get; set ; }
		public PaymentDetailsViewModel PaymentPreferences { get; private set; }

		public AsyncCommand CancelCommand
        {
            get
            {
				return GetCommand(() =>
				{
					ReturnResult(new PaymentInformation
					{
						CreditCardId = DefaultPaymentInformations.CreditCardId,
						TipPercent = DefaultPaymentInformations.TipPercent,
					});
				});
            }
        }

		public AsyncCommand SaveCommand
        {
            get
            {
				return GetCommand(() =>
				{
                    if (this.Services().Account.CurrentAccount.DefaultCreditCard == null)
					{
                        this.Services().Account.UpdateSettings(this.Services().Account.CurrentAccount.Settings, PaymentPreferences.SelectedCreditCardId, 
                                    this.Services().Account.CurrentAccount.DefaultTipPercent);
					}

					ReturnResult(new PaymentInformation
					{
						CreditCardId = PaymentPreferences.SelectedCreditCardId,
						TipPercent = PaymentPreferences.Tip,
					});
				});
            }
        }
	}
}

