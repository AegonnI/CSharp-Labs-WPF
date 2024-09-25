using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Labs_WPF
{
    public class BinaryAttack : Lab2v13
    {
        public bool evilX;
        public bool evilY;

        public BinaryAttack() : base()
        { 
            evilX = (evilY = false);
        }

        public BinaryAttack(bool evilX, bool evilY)
        {
            this.evilX = evilX;
            this.evilY = evilY;
        }

        public BinaryAttack(bool x, bool y, bool evilX, bool evilY) : base(x, y)
        {
            this.evilX = evilX;
            this.evilY = evilY;
        }

        public void Plus()
        {
            X = X != Y;
            Y = !Y;
        }

        public void Minus()
        {
            X = X == Y;
            Y = !Y;
        }
    }
}
