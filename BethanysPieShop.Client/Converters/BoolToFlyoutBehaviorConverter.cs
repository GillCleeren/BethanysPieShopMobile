using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.Client.Converters
{
    public class BoolToFlyoutBehaviorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool state = (bool)value;

            return (state == true ? FlyoutBehavior.Flyout : FlyoutBehavior.Disabled);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
