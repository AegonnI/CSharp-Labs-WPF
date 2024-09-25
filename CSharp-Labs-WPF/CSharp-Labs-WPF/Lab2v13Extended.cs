using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Labs_WPF
{
    public class Lab2v13Extended : Lab2v13
    {
        public bool Z;

        public Lab2v13Extended() : base()
        {
            Z = false;
        }

        public Lab2v13Extended(bool x, bool y, bool z) : base(x, y)
        {
            Z = z;
        }

        public Lab2v13Extended(Lab2v13Extended o) : base(o.X, o.Y)
        {
            Z = o.Z;
        }

        public Lab2v13Extended(Lab2v13 o, bool z) : base(o)
        {
            Z = z;
        }

        public bool ExtendedImplication()
        {
            return !Implication() || Z;
        }

        public override string ToString()
        {
            return X.ToString() + " " + Y.ToString() + " " + Z.ToString();
        }
    }
}
