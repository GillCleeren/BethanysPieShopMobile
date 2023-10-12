﻿using System.Globalization;

namespace BethanysPieShop.Client.Converters;

public class CountToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var v = (int)value;
        var p = bool.Parse(parameter.ToString());
        return p ? v != 0 : v == 0;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}