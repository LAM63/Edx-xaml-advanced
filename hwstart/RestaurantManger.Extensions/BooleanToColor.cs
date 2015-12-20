using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.UI.Xaml.Data;
using Windows.UI;

namespace RestaurantManager.Extensions
{
    public class BooleanToColor : IValueConverter
    {
        public Color TrueColor { get; set; }
        public Color FalseColor { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (bool)value ? TrueColor : FalseColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            //Not needed by the application.
            return (bool)(value = TrueColor) ? true : false;

        }

    }
}
