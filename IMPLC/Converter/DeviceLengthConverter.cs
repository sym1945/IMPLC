using System;
using System.Globalization;
using System.Windows.Controls;

namespace IMPLC
{
    public class DeviceLengthConverter : ConverterBase<DeviceLengthConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int intValue)
                return intValue.ToString("X");

            return value;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string inputValue = value.ToString();

            if (int.TryParse(inputValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int intValue))
            {
                return intValue;
            }

            return inputValue;
        }
    }
}