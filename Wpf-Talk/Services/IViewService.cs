using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wpf_Talk.Services
{
    internal interface IViewService
    {
        void ShowView<TView, TViewModel>(object? parms = null)
            where TView : Window
            where TViewModel : ObservableObject;
        void ShowChatRoom(int my, int op);
    }
}
