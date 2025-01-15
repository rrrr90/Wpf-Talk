using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf_Talk.Models;
using Wpf_Talk.Repositories;
using Wpf_Talk.ViewModels.Bases;

namespace Wpf_Talk.ViewModels
{
    class ChatRoomViewModel : ViewModelBase, IParameterReceiver
    {
        private readonly IChattingRepository _chattingRepository;
        private ChattingItem[] _chattings;

        public ChattingItem[] Chattings
        {
            get { return _chattings; }
            set { SetProperty(ref _chattings, value); }
        }

        public int MyUid { get; set; }
        public int OpUid { get; set; }

        public ChatRoomViewModel(IChattingRepository chattingRepository)
        {
            this._chattingRepository = chattingRepository;
        }

        private void LoadChattings()
        {
            Chattings = _chattingRepository.GetChattings(MyUid, OpUid);

            //MessageBox.Show($"sender: {MyUid} recver: {OpUid} " + chattings.Length.ToString());
        }

        public void ReceiveParameter(object parameter)
        {
            if (parameter is not int[] ids) throw new Exception("ID");
            MyUid = ids[0];
            OpUid = ids[1];
            LoadChattings();
        }
    }
}
