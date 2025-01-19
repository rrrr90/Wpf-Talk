using CommunityToolkit.Mvvm.Input;
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
    internal class ChattingViewModel : ViewModelBase, IParameterReceiver
    {
        private int _myUid = -1;
        private readonly IChattingRepository _chattingRepository;
        private readonly IViewService _viewService;

        private ChattingListItem[] _chattings = Array.Empty<ChattingListItem>();

        public ChattingListItem[] Chattings
        {
            get { return _chattings; }
            set { SetProperty(ref _chattings, value); }
        }

        public ChattingViewModel(IChattingRepository chattingRepository, IViewService viewService)
        {
            this._chattingRepository = chattingRepository;
            this._viewService = viewService;
        }

        private void LoadChattingList()
        {
            Chattings = _chattingRepository.GetLastChattings(_myUid).Reverse().ToArray();
        }

        public void ReceiveParameter(object parameter)
        {
            _myUid = parameter is int uid ? uid : -1;
            LoadChattingList();
        }

        public ICommand OpenChatRoomCommand => new RelayCommand<object?>(OpenChatRoom);
        private void OpenChatRoom(object? obj)
        {
            if (obj is not int opuid) return;
            _viewService.ShowChatRoom(_myUid, opuid);
        }
    }
}
