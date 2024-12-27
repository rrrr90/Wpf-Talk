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

namespace Wpf_Talk.ViewModels
{
    internal partial class MainViewModel : ObservableObject
    {
        private INotifyPropertyChanged _currentViewModel;
        private readonly MainNavigationStore _mainNavigationStore;

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

        public MainViewModel(MainNavigationStore mainNavigationStore)
        {
            _currentViewModel = App.Current.Services.GetService<SignInViewModel>()!;
            this._mainNavigationStore = mainNavigationStore;
            _mainNavigationStore.CurrentViewModelChanged += CurrentViewModelChanged;
        }

        private void CurrentViewModelChanged()
        {
            CurrentViewModel = _mainNavigationStore.CurrentViewModel;
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
