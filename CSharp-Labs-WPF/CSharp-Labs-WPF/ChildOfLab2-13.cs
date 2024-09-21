using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Labs_WPF
{
    public class ChildOfLab2_13 : Lab2_13
    {
        public ChildOfLab2_13() : base()
        { 
        
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
