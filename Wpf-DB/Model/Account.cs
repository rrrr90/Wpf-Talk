using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_DB.Model
{
    public class Account
    {
        public int ID { get; set; } = default(int);
        public string Email {  get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Nickname { get; set; } = string.Empty;
        public string CellPhone { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"ID:{ID}, Email:{Email}, Pwd:{Password}, Nickname:{Nickname}, Phone:{CellPhone}";
        }
    }
}
