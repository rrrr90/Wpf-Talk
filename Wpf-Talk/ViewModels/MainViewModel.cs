using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Wpf_Talk.Services;
using Wpf_Talk.Stores;
using Wpf_Talk.ViewModels.Bases;

namespace Wpf_Talk.ViewModels
{
    internal class MainViewModel : ViewModelBase, IParameterReceiver
    {
        private readonly INavigationService _navigationService;
        private readonly NavigationStore _navigationStore;

        private INotifyPropertyChanged? _currentViewModel;
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

        private int _myUid;
        public int MyUid { get => _myUid; }

        public MainViewModel(INavigationService navigationService, NavigationStore navigationStore)
        {
            //https://rhkdrmfh.tistory.com/139
            this._navigationService = navigationService;
            this._navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += CurrentViewModelChanged;
            _navigationService.Navigate(MainNavType.FriendView);
        }

        private void CurrentViewModelChanged()
        {
            CurrentViewModel = _navigationStore.CurrentViewModel;
        }

        public void ReceiveParameter(object parameter)
        {
            if (parameter is int id)
            {
                _myUid = id;
            }
                else
            {
                throw new Exception("UID");
            }
        }

        public ICommand ToFriendViewCommand => new RelayCommand(ToFriendView);
        public ICommand ToChattingViewCommand => new RelayCommand(ToChattingView);
        public ICommand ToMoreViewCommand => new RelayCommand(ToMoreView);

        private void ToFriendView()
        {
            _navigationService.Navigate(MainNavType.FriendView);
        }
        private void ToChattingView()
        {
            _navigationService.Navigate(MainNavType.ChattingView);
        }
        private void ToMoreView()
        {
            _navigationService.Navigate(MainNavType.MoreView);
        }
    }
}
