using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace Rance.Tools
{
    public class BoolBrushConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool effective = (bool)value;
            if (effective)
                return new SolidColorBrush(Colors.Red);
            else
                return new SolidColorBrush(Colors.Gray);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Brush brush = (Brush)value;
            if (brush == new SolidColorBrush(Colors.Red))
                return true;
            else
                return false;
        }
    }
}
