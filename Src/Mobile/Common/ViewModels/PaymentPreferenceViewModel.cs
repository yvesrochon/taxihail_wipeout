using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.MvvmCross.Interfaces.Commands;

namespace apcurium.MK.Booking.Mobile.ViewModels
{
    public class PaymentPreferenceViewModel : BaseViewModel
    {
        public PaymentPreferenceViewModel()
        {
            
        }

        public IMvxCommand ConfirmPreference
        {
            get
            {
                return GetCommand(() =>
                {
                    this.Close();
                });
            }
        }
    }
}