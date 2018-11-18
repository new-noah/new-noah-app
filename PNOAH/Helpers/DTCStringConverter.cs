// itelenkov
// /Users/itelenkov/Projects/PNOAH/PNOAH/Helpers
using System;
using System.Globalization;
using Xamarin.Forms;
namespace PNOAH.Helpers
{
    public class DTCStringConverter: IValueConverter
    {
        public DTCStringConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"{(string)value} DCT";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
