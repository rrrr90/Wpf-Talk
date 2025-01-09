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
using Wpf_Talk.ViewModels.Bases;
using Wpf_Talk.Views;

namespace Wpf_Talk.ViewModels
{
    internal class SignInViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IAccountRepository _accountRepository;
        private readonly IViewService _viewService;
        private string _email = string.Empty;
        private string _password = string.Empty;
        public string Email { get => _email; set { SetProperty(ref _email, value); } }
        public string Password { get => _password; set { SetProperty(ref _password, value); } }

        public SignInViewModel(INavigationService navigationService, IAccountRepository accountRepository, IViewService viewService)
        {
            this._navigationService = navigationService;
            this._accountRepository = accountRepository;
            this._viewService = viewService;
        }

        public ICommand SignInCommand => new RelayCommand<object>(SignIn);
        public ICommand ToSignUpCommand => new RelayCommand(ToSignUp);
        public ICommand ToChangePwdCommand => new RelayCommand(ToChangePwd);

        private void SignIn(object? _)
        {
            int uid = _accountRepository.GetUid(new Account()
            {
                Email = Email,
                Password = Password
            });
            if (uid >= 0)
            {
                ToMainView(uid);
                App.Current.Services.GetService<LoginView>()!.Close();
            }
            else
            {
                MessageBox.Show("Incorrect password.");
            }
        }
        private void ToSignUp()
        {
            _navigationService.Navigate(NavType.SignUpView);
        }
        private void ToChangePwd()
        {
            _navigationService.Navigate(NavType.ChangePwdView);
        }
        private void ToMainView(int uid)
        {
            _viewService.ShowView<MainView, MainViewModel>(uid);
        }
    }
}
