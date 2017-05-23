using System;
using System.Globalization;
using System.Windows.Data;

namespace DingWK.Graphic2D.Wpf.Converters
{
    public class DoubleNagtiveConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return -(double)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return -(double)value;
        }
    }
}
