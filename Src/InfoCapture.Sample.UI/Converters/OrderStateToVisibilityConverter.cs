using InfoCapture.Sample.Data;
using System;
using System.Windows;
using System.Windows.Data;

namespace InfoCapture.Sample.UI.Converters
{
    [ValueConversion(typeof(OrderState), typeof(Visibility))]
    public class OrderStateToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var orderState = (OrderState)value;

            return orderState == OrderState.InMaking ? Visibility.Visible : Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
