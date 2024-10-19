using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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

        public static Visibility VisibleReverse(Visibility visibility)
        {
            if (visibility == Visibility.Visible)
            {
                return Visibility.Hidden;
            }
            return Visibility.Visible;
        }

        public static Brush ChangeColor(bool x)
        {
            if (x)
            {
                return Brushes.Green;
            }
            return Brushes.Black;
        }

        public static void ChangeTheme(bool isDarkTheme, ResourceDictionary Theme)
        {
            if (isDarkTheme)
            {
                Theme.Source = new Uri("Themes/Dark.xaml", UriKind.Relative);
            }
            else
            {
                Theme.Source = new Uri("Themes/Light.xaml", UriKind.Relative);
            }
        }
    }
}
