using System;

namespace CSharp_Labs_WPF
{
    internal class Account
    {
        private string fullName;
        private DateTime date;

        public Account()
        {
            fullName = "";
            date = DateTime.MinValue;
        }
        public Account(string fullName, DateTime date)
        {
            this.fullName = fullName;
            this.date = date;
        }

        public override string ToString() 
        {
            return string.Join(" ", fullName, date.ToString().Substring(0, 10));
        }
    }
}
