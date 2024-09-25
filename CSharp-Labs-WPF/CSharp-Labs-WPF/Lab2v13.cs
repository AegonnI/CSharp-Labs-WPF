using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Labs_WPF
{
    public class Lab2v13
    {
        public bool X;
        public bool Y;

        public Lab2v13()
        {
            X = (Y = false);
        }

        public Lab2v13(bool x, bool y)
        {
            X = x;
            Y = y;
        }

        public Lab2v13(Lab2v13 o)
        {
            X = o.X;
            Y = o.Y;
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
