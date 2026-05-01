using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Monetrixa.BiometricMobile.App.Common.Converters
{
    public class InverseBoolConverter : IValueConverter
    {
        public object Convert(
            object? value,
            Type targetType,
            object? parameter,
            CultureInfo culture)
        {
            return value is bool boolValue && !boolValue;
        }

        public object ConvertBack(
            object? value,
            Type targetType,
            object? parameter,
            CultureInfo culture)
        {
            return value is bool boolValue && !boolValue;
        }
    }
}
