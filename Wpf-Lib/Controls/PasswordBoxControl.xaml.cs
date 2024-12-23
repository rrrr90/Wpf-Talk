using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_Lib.Controls
{
    /// <summary>
    /// PasswordBoxControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PasswordBoxControl : UserControl
    {
        bool _isFirst = true;

        public PasswordBoxControl()
        {
            InitializeComponent();

            txtBox.TextChanged += TxtBox_TextChanged;
            pwdBox.PasswordChanged += PwdBox_PasswordChanged;
        }

        private void PwdBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Password = pwdBox.Password;
        }

        private void TxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(_isFirst || DesignerProperties.GetIsInDesignMode(this))
            {
                if(pwdBox.Password != txtBox.Text)
                {
                    pwdBox.Password = txtBox.Text;
                }
                _isFirst = false;
            }
        }

        public new Brush BorderBrush
        {
            get { return (Brush)GetValue(BorderBrushProperty); }
            set { SetValue(BorderBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BorderBrush.  This enables animation, styling, binding, etc...
        public static new readonly DependencyProperty BorderBrushProperty =
            DependencyProperty.Register("BorderBrush", typeof(Brush), typeof(PasswordBoxControl), new UIPropertyMetadata(Brushes.SkyBlue));

        public new Thickness BorderThickness
        {
            get { return (Thickness)GetValue(BorderThicknessProperty); }
            set { SetValue(BorderThicknessProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BorderThickness.  This enables animation, styling, binding, etc...
        public static new readonly DependencyProperty BorderThicknessProperty =
            DependencyProperty.Register("BorderThickness", typeof(Thickness), typeof(PasswordBoxControl), new UIPropertyMetadata(new Thickness(1)));

        public string WaterMarkText
        {
            get { return (string)GetValue(WaterMarkTextProperty); }
            set { SetValue(WaterMarkTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WaterMarkText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WaterMarkTextProperty =
            DependencyProperty.Register("WaterMarkText", typeof(string), typeof(PasswordBoxControl), new PropertyMetadata(null));

        public Brush WaterMarkTextColor
        {
            get { return (Brush)GetValue(WaterMarkTextColorProperty); }
            set { SetValue(WaterMarkTextColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WaterMarkTextColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WaterMarkTextColorProperty =
            DependencyProperty.Register("WaterMarkTextColor", typeof(Brush), typeof(PasswordBoxControl), new UIPropertyMetadata(Brushes.Gray));

        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Password.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(PasswordBoxControl), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public bool Validating
        {
            get { return (bool)GetValue(ValidatingProperty); }
            set { SetValue(ValidatingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Validating.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValidatingProperty =
            DependencyProperty.Register("Validating", typeof(bool), typeof(PasswordBoxControl), new UIPropertyMetadata(false));
    }
}
