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
        private readonly LoginNavigationStore _loginNavigationStore;
        private INotifyPropertyChanged CurrentViewModel
        {
            set=> _loginNavigationStore.CurrentViewModel = value;
        }

        public NavigationService(LoginNavigationStore mainNavigationStore)
        {
            this._loginNavigationStore = mainNavigationStore;
        }

        public void Navigate(NavType navType)
        {
            switch (navType)
            {
                case NavType.SignUpView:
                    CurrentViewModel = App.Current.Services.GetService<SignUpViewModel>()!;
                    break;
                case NavType.SignInView:
                    CurrentViewModel = App.Current.Services.GetService<SignInViewModel>()!;
                    break;
                case NavType.ChangePwdView:
                    CurrentViewModel = App.Current.Services.GetService<ChangePwdViewModel>()!;
                    break;
                default:
                    return;
            }
        }
    }
}
