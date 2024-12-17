using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Wpf_Lib.Extensions
{
    public static class FindParentExtensions
    {
        public static T? FindParent<T>(this DependencyObject child)
    where T : DependencyObject
        {
            return FindParent<T>(child, null);
        }


        public static T? FindParent<T>(this DependencyObject child, string? parentName)
            where T : DependencyObject
        {
            var parent = VisualTreeHelper.GetParent(child);
            if (parent == null) return null;

            var frameworkElement = parent as FrameworkElement;
            if (parentName == null ||
                frameworkElement is T && parentName == frameworkElement.Name) return parent as T;

            return FindParent<T>(parent, parentName);
        }
    }
}
