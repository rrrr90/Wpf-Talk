using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Talk.Models
{
    public class ChattingItem
    {
        public int Sender { get; set; } = default;
        public int Recver { get; set; } = default;
        public string Message { get; set; } = string.Empty;

        private DateTime _sendDate = DateTime.MinValue;
        public string SendDate
        {
            get
            {
                if (_sendDate.ToShortDateString() == DateTime.Now.ToShortDateString()) return _sendDate.ToShortTimeString();
                else return _sendDate.ToShortDateString();
            }
            set
            {
                _sendDate = DateTime.Parse(value);
            }
        }
    }
}
