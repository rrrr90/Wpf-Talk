using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf_Talk.ViewModels.Bases;

namespace Wpf_Talk.ViewModels
{
    internal class MainViewModel : ViewModelBase, IParameterReceiver
    {
        private int _myUid;
        public int MyUid { get => _myUid; }

        public MainViewModel()
        {
            //https://rhkdrmfh.tistory.com/139
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
    }
}
