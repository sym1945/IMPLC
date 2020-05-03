using System;
using System.Globalization;

namespace IMPLC
{
    public class IconConverter : ConverterBase<IconConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool isRuning))
                return $@"Resources/Icons/IdleIcon.ico";

            return $@"Resources/Icons/{(isRuning ? "runIcon.ico" : "IdleIcon.ico")}"; 
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}