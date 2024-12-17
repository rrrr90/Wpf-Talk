using FontAwesome6;
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
    internal class WindowStateIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            WindowState? state = value as WindowState?;
            return state == WindowState.Normal
                ? EFontAwesomeIcon.Regular_Square
                : EFontAwesomeIcon.Solid_DownLeftAndUpRightToCenter;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
