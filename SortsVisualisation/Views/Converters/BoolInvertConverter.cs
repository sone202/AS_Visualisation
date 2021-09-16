using System;
using Windows.UI.Xaml.Data;

namespace SortsVisualisation.Views.Converters
{
    public class BoolInvertConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return !(value as bool?);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return !(value as bool?);
        }
    }
}
