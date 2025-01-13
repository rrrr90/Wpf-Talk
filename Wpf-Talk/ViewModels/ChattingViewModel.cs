using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Talk.Models;
using Wpf_Talk.Repositories;
using Wpf_Talk.ViewModels.Bases;

namespace Wpf_Talk.ViewModels
{
    internal class ChattingViewModel : ViewModelBase, IParameterReceiver
    {
        private int _myUid = -1;
        private readonly IChattingRepository _chattingRepository;

        private ChattingListItem[] _chattings = Array.Empty<ChattingListItem>();

        public ChattingListItem[] Chattings
        {
            get { return _chattings; }
            set { SetProperty(ref _chattings, value); }
        }

        public ChattingViewModel(IChattingRepository chattingRepository)
        {
            this._chattingRepository = chattingRepository;
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


    }
}
