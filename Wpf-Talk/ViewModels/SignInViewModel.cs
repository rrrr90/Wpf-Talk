using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Wpf_Talk.Models;
using Wpf_Talk.Repositories;
using Wpf_Talk.Services;

namespace Wpf_Talk.ViewModels
{
    internal class SignInViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly IAccountRepository _accountRepository;

        private string _email = string.Empty;
        private string _password = string.Empty;
        public string Email { get => _email; set { SetProperty(ref _email, value); } }
        public string Password { get => _password; set { SetProperty(ref _password, value); } }

        public SignInViewModel(INavigationService navigationService, IAccountRepository accountRepository)
        {
            this._navigationService = navigationService;
            this._accountRepository = accountRepository;
        }

        public ICommand SignInCommand => new RelayCommand<object>(SignIn);
        public ICommand ToSignUpCommand => new RelayCommand(ToSignUp);
        public ICommand ToChangePwdCommand => new RelayCommand(ToChangePwd);

        private void SignIn(object? _)
        {
            long uid = _accountRepository.GetUid(new Account()
            {
                Email = Email,
                Password = Password
            });
            MessageBox.Show(uid.ToString());

        }
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
