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
    internal class FriendViewModel : ViewModelBase, IParameterReceiver
    {
        private List<FriendItem> _friends = new List<FriendItem>();
        public List<FriendItem> Friends { get => _friends; set { SetProperty(ref _friends, value); } }

        private Account? _myAccount;
        public Account? MyAccount { get => _myAccount; set { SetProperty(ref _myAccount, value); } }
        public string Source { get => "D:\\Picture\\인장주작은뭐야.jpg"; }

        private readonly IAccountRepository _accountRepository;

        public FriendViewModel(IAccountRepository accountRepository)
        {
            this._accountRepository = accountRepository;
            //LoadFriendList();
        }

        private void LoadFriendList()
        {
            Account[] accounts = _accountRepository.GetAll();
            List<FriendItem> list = new List<FriendItem>();
            foreach (Account account in accounts)
            {
                if (account.ID == MyAccount?.ID) continue;
                list.Add(new FriendItem(text: account.Nickname, "D:\\Picture\\인장주작은뭐야.jpg"));
            }
            Friends = list;
        }

        public void ReceiveParameter(object parameter)
        {
            if (parameter is int myUid)
            {
                MyAccount = Array.Find(_accountRepository.GetAll(), element => element.ID == myUid);
            }
            LoadFriendList();
        }
    }
}
