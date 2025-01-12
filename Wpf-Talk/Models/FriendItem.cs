using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Talk.Models
{
    public class FriendItem
    {
        public string Text { get; set; }
        public string Source { get; set; }

        public FriendItem(string text, string source)
        {
            Text = text;
            Source = source;
        }
    }
}
