using BethanysPieShop.Client.Constants;
using System.Globalization;

namespace BethanysPieShop.Client.Converters
{
    public class ImageNameToUrlConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"{ApiConstants.BaseImagesUrl}{value}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
