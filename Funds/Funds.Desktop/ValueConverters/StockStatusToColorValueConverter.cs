using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using Funds.Core.Models;

namespace Funds.Desktop.ValueConverters
{
    public class StockStatusToColorValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var stock = value as Stock;

            return stock?.IsRed ?? false ? Brushes.Red : Brushes.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
