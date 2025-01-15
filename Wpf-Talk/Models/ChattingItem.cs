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
        public string SendDate { get; set; } = string.Empty;

    }
}
