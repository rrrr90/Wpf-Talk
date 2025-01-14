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
    internal class MoreViewModel : ViewModelBase, IParameterReceiver
    {
        private readonly IAccountRepository _accountRepository;
        private int _myUid = -1;
        private Account? _myAccount;

        public Account? MyAccount
        {
            get { return _myAccount; }
            set { SetProperty(ref _myAccount, value); }
        }

        public MoreViewModel(IAccountRepository accountRepository)
        {
            this._accountRepository = accountRepository;
        }

        public void ReceiveParameter(object parameter)
        {
            _myUid = parameter is int uid ? uid : -1;
            MyAccount = _accountRepository.GetAccount(_myUid);
        }
    }
}
