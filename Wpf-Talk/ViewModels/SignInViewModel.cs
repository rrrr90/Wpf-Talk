using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wpf_Talk.Services;

namespace Wpf_Talk.ViewModels
{
    internal class SignInViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;

        public SignInViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;
        }

        public ICommand ToSignUpCommand => new RelayCommand(ToSignUp);
        public ICommand ToChangePwdCommand => new RelayCommand(ToChangePwd);

        private void ToSignUp()
        {
            _navigationService.Navigate(NavType.SignUpView);
        }
        private void ToChangePwd()
        {
            _navigationService.Navigate(NavType.ChangePwdView);
        }
    }
}
