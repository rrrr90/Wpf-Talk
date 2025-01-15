using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Wpf_Lib.Controls
{
    public class ListBoxBehavior
    {
        public static bool GetUseOnItemsAdded(DependencyObject obj)
        {
            return (bool)obj.GetValue(UseOnItemsAddedProperty);
        }

        public static void SetUseOnItemsAdded(DependencyObject obj, bool value)
        {
            obj.SetValue(UseOnItemsAddedProperty, value);
        }

        // Using a DependencyProperty as the backing store for UseOnItemsAdded.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UseOnItemsAddedProperty =
            DependencyProperty.RegisterAttached("UseOnItemsAdded", typeof(bool), typeof(ListBoxBehavior), new PropertyMetadata(false, onUseOnItemsAdded));

        private static void onUseOnItemsAdded(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not ListBox listbox) return;

            if ((bool)e.NewValue == (bool)e.OldValue) return;

            if ((bool)e.NewValue)
            {
                listbox.Loaded += ListBox_Loaded;
            }
            else
            {
                listbox.Loaded -= ListBox_Loaded;
            }
        }

        static void ListBox_Loaded(object sender,  RoutedEventArgs e)
        {
            if (sender is not ListBox listbox) return;
            listbox?.ScrollIntoView(listbox.Items.GetItemAt(listbox.Items.Count - 1));
        }
    }
}
