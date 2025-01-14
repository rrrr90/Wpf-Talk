using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Talk.ViewModels.Bases;

namespace Wpf_Talk.ViewModels
{
    class ChatRoomViewModel : ViewModelBase, IParameterReceiver
    {
        public int MyUid { get; set; }
        public int OpUid { get; set; }


        public void ReceiveParameter(object parameter)
        {
            if (parameter is not int[] ids) throw new Exception("ID");
            MyUid = ids[0];
            OpUid = ids[1];
        }
    }
}
