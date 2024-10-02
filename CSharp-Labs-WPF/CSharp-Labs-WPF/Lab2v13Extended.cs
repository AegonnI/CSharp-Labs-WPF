using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Labs_WPF
{
    public class Lab2v13Extended : Lab2v13
    {
        public bool z;

        public Lab2v13Extended() : base()
        {
            z = false;
        }

        public Lab2v13Extended(bool x, bool y, bool z) : base(x, y)
        {
            this.z = z;
        }

        public Lab2v13Extended(Lab2v13Extended o) : base(o.x, o.Y)
        {
            z = o.z;
        }

        public Lab2v13Extended(Lab2v13 o, bool z) : base(o)
        {
            this.z = z;
        }

        public bool ExtendedImplication()
        {
            return !Implication() || z;
        }

        public override string ToString()
        {
            return x.ToString() + " " + Y.ToString() + " " + z.ToString();
        }
    }
}
