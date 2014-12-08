using System.Collections;
using System.Globalization;

using Cirrious.CrossCore.UI;
using Cirrious.MvvmCross.Plugins.Visibility;

namespace apcurium.MK.Booking.Mobile.BindingConverter
{
    public class NoValueToVisibilityConverter : MvxBaseVisibilityValueConverter
    {
        protected override MvxVisibility Convert(object value, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return MvxVisibility.Visible;
            }
            var enumerable = value as IEnumerable;
            if (enumerable != null)
            {
                if (!enumerable.GetEnumerator().MoveNext())
                {
                    return MvxVisibility.Visible;
                }
            }
            return MvxVisibility.Collapsed;
        }
    }
}