using System;
using System.Globalization;

namespace IMPLC
{
    public class ReverseBoolConverter : ConverterBase<ReverseBoolConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool boolean))
                return value;

            return !boolean;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}