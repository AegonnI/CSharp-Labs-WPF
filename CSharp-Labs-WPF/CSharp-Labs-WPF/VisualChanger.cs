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
    internal static class VisualChanger
    {
        public static Visibility ChangeVisible(bool x)
        {
            if (x)
            {
                return Visibility.Visible;
            }
            return Visibility.Hidden;
        }

        public static void ChangeVisible(bool x, params Button[] buttons)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Visibility = ChangeVisible(x);
            }
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

        public static Matrix CreateMatrix(TextBox userValue1, TextBox userValue2, TextBox userValue3, Button ChooseConstructor1, Button ChooseConstructor2, Button ChooseConstructor3)
        {
            if (LabChecker.IsPosetiveInt(userValue1.Text))
            {
                if (!ChooseConstructor1.IsEnabled)
                {
                    if (LabChecker.IsPosetiveInt(userValue2.Text) &&
                        LabChecker.IsRealDuoMatrix(userValue3.Text.Split(' '),
                        int.Parse(userValue1.Text) * int.Parse(userValue2.Text))
                       )
                        return new Matrix(int.Parse(userValue1.Text),
                                          int.Parse(userValue2.Text),
                                          LabConverter.StringToIntArr(userValue3.Text.Split(' '))
                                         );
                    else
                    {
                        throw new Exception("Incorrect values for Matrix");
                    }
                }
                if (!ChooseConstructor2.IsEnabled)
                {
                    if (LabChecker.IsInt(userValue2.Text))
                    {
                        return userValue3.Text == "" ?
                            new Matrix(int.Parse(userValue1.Text), int.Parse(userValue2.Text)) :
                            new Matrix(int.Parse(userValue1.Text), int.Parse(userValue2.Text), int.Parse(userValue3.Text));
                    }
                    else
                    {
                        throw new Exception("Incorrect values for Matrix");
                    }
                }
                if (!ChooseConstructor3.IsEnabled)
                    return new Matrix(int.Parse(userValue1.Text));
            }
            throw new Exception("Constructor is unchoosen");
        }
    }
}
