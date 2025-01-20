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
using Wpf_Talk.ViewModels.Bases;

namespace Wpf_Talk.ViewModels
{
    class ChatRoomViewModel : ViewModelBase, IParameterReceiver
    {
        private readonly IChattingRepository _chattingRepository;
        private List<ChattingItem> _chattings = new List<ChattingItem>();

        public List<ChattingItem> Chattings
        {
            get { return _chattings; }
            set { SetProperty(ref _chattings, value); }
        }

        public int MyUid { get; set; }
        public int OpUid { get; set; }

        private string _myMessage = string.Empty;
        public string MyMessage { get => _myMessage; set { SetProperty(ref _myMessage, value); } }

        public ChatRoomViewModel(IChattingRepository chattingRepository)
        {
            this._chattingRepository = chattingRepository;
        }

        private void LoadChattings()
        {
            Chattings = _chattingRepository.GetChattings(MyUid, OpUid).ToList();
        }

        public void ReceiveParameter(object parameter)
        {
            if (parameter is not int[] ids) throw new Exception("ID");
            MyUid = ids[0];
            OpUid = ids[1];
            LoadChattings();
        }

        public ICommand SendMessageCommand => new RelayCommand<object>(SendMessage);
        public ICommand MessageBoxEnterCommand => new RelayCommand<object>(SendMessage);

        private void SendMessage(object? obj)
        {
            if (string.IsNullOrEmpty(MyMessage.Trim())) return;

            _chattingRepository.SendMessage(sender: MyUid, recver: OpUid, message: MyMessage);

            ChattingItem item = new ChattingItem()
            {
                Sender = MyUid,
                Recver = OpUid,
                Message = MyMessage,
                SendDate = DateTime.Now.ToString()
            };

            List<ChattingItem> list = _chattings.ToList();
            list.Add(item);
            Chattings = list;

            MyMessage = string.Empty;
        }
    }
}
