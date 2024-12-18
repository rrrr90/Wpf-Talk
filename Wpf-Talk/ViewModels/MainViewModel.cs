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

namespace Wpf_Talk.ViewModels
{
    internal partial class MainViewModel : ObservableObject
    {
        private INotifyPropertyChanged _currentViewModel;
        public INotifyPropertyChanged CurrentViewModel
        {
            get => _currentViewModel;
            set { SetProperty(ref _currentViewModel, value); }
        }

        public MainViewModel()
        {
            _currentViewModel = App.Current.Services.GetService<SignInViewModel>()!;
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
