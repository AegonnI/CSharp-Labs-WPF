using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Labs_WPF
{
    public class Lab2v13
    {
        protected bool x;
        protected bool y;

        public Lab2v13()
        {
            x = (y = false);
        }

        public Lab2v13(bool x, bool y)
        {
            this.x = x;
            this.y = y;
        }

        public Lab2v13(Lab2v13 o)
        {
            x = o.x;
            y = o.Y;
        }

        public bool Implication()
        {
            return !x || y;
        }

        public override string ToString()
        {
            return x.ToString() + " " + y.ToString();
        }

        public bool X
        {
            set { x = value; }
            get { return x;}
        }

        public bool Y
        {
            set { y = value; }
            get { return y; }
        }
    }
}
