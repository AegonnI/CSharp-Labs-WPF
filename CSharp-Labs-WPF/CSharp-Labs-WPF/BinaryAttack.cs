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
