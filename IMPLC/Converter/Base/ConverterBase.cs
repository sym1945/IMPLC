using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace IMPLC
{
    public abstract class ConverterBase<T> : MarkupExtension, IValueConverter
        where T: class, new()
    {
        private static T _Converter;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _Converter ?? (_Converter = new T());
        }

        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
    }
}