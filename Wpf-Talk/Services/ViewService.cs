using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf_Talk.ViewModels;
using Wpf_Talk.ViewModels.Bases;
using Wpf_Talk.Views;

namespace Wpf_Talk.Services
{
    internal class ViewService : IViewService
    {
        private readonly IServiceProvider _serviceProvider;

        public ViewService(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        public void ShowView<TView, TViewModel>(object? parms = null)
            where TView : Window
            where TViewModel : ObservableObject
        {
            Window view = (Window)_serviceProvider.GetService(typeof(TView))!;
            ObservableObject? viewModel = (ObservableObject?)_serviceProvider.GetService(typeof(TViewModel));

            if(viewModel is IParameterReceiver receiver && parms is not null)
            {
                receiver.ReceiveParameter(parms);
            }

            view.DataContext = viewModel;
            view.Show();
        }

        public void ShowChatRoom(int my, int op)
        {
            var windows = Application.Current.Windows.OfType<ChatRoomView>().ToList();
            var window = windows.FirstOrDefault(x => ((ChatRoomViewModel)x.DataContext).OpUid == op);
            if (window is null) ShowView<ChatRoomView, ChatRoomViewModel>(new int[] { my, op });
            else window.Activate();
        }

        private static bool ActivateWindow<TView>()
            where TView : Window
        {
            var window = Application.Current.Windows.OfType<TView>();
            if (window.Any())
            {
                window.ElementAt(0).Activate();
                return true;
            }
            return false;
        }
    }
}
