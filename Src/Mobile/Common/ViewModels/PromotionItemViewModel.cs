using System;
using System.Windows.Input;
using apcurium.MK.Booking.Api.Contract.Resources;
using apcurium.MK.Booking.Mobile.Extensions;

namespace apcurium.MK.Booking.Mobile.ViewModels
{
    public class PromotionItemViewModel : SelectableItemViewModel<ActivePromotion>
    {
        public PromotionItemViewModel(ActivePromotion activePromotion, ICommand promotionRedeemedCommand)
            : base(activePromotion, promotionRedeemedCommand)
        {
            Name = activePromotion.Name;
            Description = activePromotion.Description;
            ExpiringSoonWarning = GenerateExpiringSoonWarning(activePromotion.ExpirationDate);
            IsExpanded = false;
        }

        public ICommand SelectPromotion
        {
            get
            {
                return this.GetCommand(() =>
                {
                    IsExpanded = !IsExpanded;
                });
            }
        }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public string ExpiringSoonWarning { get; private set; }

        private bool _isExpanded;
        public bool IsExpanded
        {
			get { return _isExpanded; }
            set
            {
				if (_isExpanded != value)
                {
					_isExpanded = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string GenerateExpiringSoonWarning(DateTime? expirationDate)
        {
            const int thresholdForWarning = 4; // In days

            if (expirationDate == null)
            {
                return string.Empty;
            }

            var daysRemaining = (expirationDate.Value - DateTime.Now).Days;
            if (daysRemaining >= thresholdForWarning)
            {
                return string.Empty;
            }
            if (daysRemaining > 1 && daysRemaining < thresholdForWarning)
            {
                return string.Format(this.Services().Localize["PromoExpiringSoonMessage"], daysRemaining);
            }
            if (daysRemaining == 1)
            {
                return this.Services().Localize["PromoExpiringIn1DayMessage"];
            }
            return this.Services().Localize["PromoExpiringToday"];
        }
    }
}