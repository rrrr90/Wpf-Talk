namespace Wpf_Talk.Models
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
