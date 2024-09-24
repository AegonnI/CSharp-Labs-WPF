using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace CSharp_Labs_WPF
{
    public static class VisualChanger
    {
        public static Visibility ChangeVisible(bool x)
        {
            if (x)
            {
                return Visibility.Visible;
            }
            return Visibility.Hidden;
        }

        public static Brush ChangeColor(bool x)
        {
            if (x)
            {
                return Brushes.Green;
            }
            return Brushes.Black;
        }
    }
}
