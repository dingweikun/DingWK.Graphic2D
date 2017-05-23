using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DingWK.Graphic2D.Wpf.Converters
{
    public class VectorToDoublesConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return (values != null && values.Length > 1) ? new Vector((double)values[0], (double)values[1]) : DependencyProperty.UnsetValue;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            Vector offset = (Vector)value;
            return new object[] { offset.X, offset.Y };
        }

    }
}
