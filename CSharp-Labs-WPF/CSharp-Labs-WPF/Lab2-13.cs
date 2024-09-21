using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Labs_WPF
{
    public class Lab2_13
    {
        public bool X;
        public bool Y;

        public Lab2_13()
        {
            X = false;
            Y = false;
        }

        public Lab2_13(bool x, bool y)
        {
            X = x;
            Y = y;
        }

        public bool Implication()
        {
            return !X || Y;
        }

        public override string ToString()
        {
            return X.ToString() + " " + Y.ToString();
        }
    }
}
