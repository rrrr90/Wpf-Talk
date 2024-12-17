using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Wpf_Talk.Converters
{
    internal class WindowStateMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            WindowState? state = value as WindowState?;

            if (state == WindowState.Normal) return new Thickness(0);
            var param = parameter as string;
            var right = param == "Exit" ? 7 : 0;
            return new Thickness(0, 7, right, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
