using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Labs_WPF
{
    public class Lab2v12Extended : Lab2v13
    {
        public bool Z;

        public Lab2v12Extended() : base()
        {
            Z = false;
        }

        public Lab2v12Extended(bool x, bool y, bool z) : base(x, y)
        {
            Z = z;
        }

        public bool ExtendedImplication()
        {
            return !X || Y;
        }

        public override string ToString()
        {
            return X.ToString() + " " + Y.ToString() + " " + Z.ToString();
        }
    }
}
