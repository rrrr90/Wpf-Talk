using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Talk.Stores;
using Wpf_Talk.ViewModels;

namespace Wpf_Talk.Services
{
    internal class NavigationService : INavigationService
    {
        private readonly NavigationStore _navigationStore;
        private INotifyPropertyChanged CurrentViewModel
        {
            set=> _navigationStore.CurrentViewModel = value;
        }

        public NavigationService(NavigationStore navigationStore)
        {
            this._navigationStore = navigationStore;
        }

        public void Navigate(Enum navType)
        {
            switch (navType)
            {
                case LoginNavType.SignUpView:
                    CurrentViewModel = App.Current.Services.GetService<SignUpViewModel>()!;
                    break;
                case LoginNavType.SignInView:
                    CurrentViewModel = App.Current.Services.GetService<SignInViewModel>()!;
                    break;
                case LoginNavType.ChangePwdView:
                    CurrentViewModel = App.Current.Services.GetService<ChangePwdViewModel>()!;
                    break;
                case MainNavType.FriendView:
                    CurrentViewModel = App.Current.Services.GetService<FriendViewModel>()!;
                    break;
                case MainNavType.ChattingView:
                    CurrentViewModel = App.Current.Services.GetService<ChattingViewModel>()!;
                    break;
                case MainNavType.MoreView:
                    CurrentViewModel = App.Current.Services.GetService<MoreViewModel>()!;
                    break;
                default:
                    return;
            }
        }
    }
}
