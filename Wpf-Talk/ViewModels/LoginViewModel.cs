using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Wpf_Talk.Stores;
using Wpf_Talk.Services;
using Wpf_Talk.ViewModels.Bases;

namespace Wpf_Talk.ViewModels
{
    internal partial class LoginViewModel : ViewModelBase
    {
        private INotifyPropertyChanged? _currentViewModel;
        private readonly LoginNavigationStore _loginNavigationStore;

        public INotifyPropertyChanged? CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                if (_currentViewModel == value)
                    return;
                 SetProperty(ref _currentViewModel, value);
            }
        }

        public LoginViewModel(LoginNavigationStore loginNavigationStore, INavigationService navigationService)
        {
            _loginNavigationStore = loginNavigationStore;
            _loginNavigationStore.CurrentViewModelChanged += CurrentViewModelChanged;
            navigationService.Navigate(NavType.SignInView);
        }

        private void CurrentViewModelChanged()
        {
            CurrentViewModel = _loginNavigationStore.CurrentViewModel;
        }

        public ICommand ToSignUpCommand => new RelayCommand(ToSignUp);
        public ICommand ToSignInCommand => new RelayCommand(ToSignIn);
        public ICommand ToChangePwdCommand => new RelayCommand(ToChangePwd);

        private void ToSignUp()
        {
            CurrentViewModel = App.Current.Services.GetService<SignUpViewModel>()!;
        }
        private void ToSignIn()
        {
            CurrentViewModel = App.Current.Services.GetService<SignInViewModel>()!;
        }
        private void ToChangePwd()
        {
            CurrentViewModel = App.Current.Services.GetService<ChangePwdViewModel>()!;
        }
    }
}
