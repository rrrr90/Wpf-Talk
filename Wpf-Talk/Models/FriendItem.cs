using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Talk.Models
{
    public class FriendItem
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public string Source { get; set; }

        public FriendItem(int id, string text, string source)
        {
            ID = id;
            Text = text;
            Source = source;
        }
    }
}
