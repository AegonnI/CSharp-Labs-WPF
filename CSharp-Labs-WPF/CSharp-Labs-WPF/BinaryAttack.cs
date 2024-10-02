using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

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
            x = x != y;
            y = !y;
        }

        public void Minus()
        {
            x = x == y;
            y = !y;
        }

        //void GenEvilBin()
        //{
        //    Random rand = new Random();
        //    if (rand.Next(2) == 1)
        //    {
        //        evilBinBox1.Fill = Brushes.Green;
        //        binaryAttack.evilX = true;
        //    }
        //    else
        //    {
        //        evilBinBox1.Fill = Brushes.Black;
        //        binaryAttack.evilX = false;

        //    }
        //    if (rand.Next(2) == 1)
        //    {
        //        evilBinBox2.Fill = Brushes.Green;
        //        binaryAttack.evilY = true;
        //    }
        //    else
        //    {
        //        evilBinBox2.Fill = Brushes.Black;
        //        binaryAttack.evilY = false;
        //    }
        //}

        //void CollisionEvent()
        //{
        //    Task.Run(() =>
        //    {
        //        Thread.Sleep(timeToMove * 1000); // Симуляция задержки

        //        // Обновляем UI после завершения операции
        //        Application.Current.Dispatcher.Invoke(() =>
        //        {
        //            if (binaryAttack.X != binaryAttack.evilX && binaryAttack.Y != binaryAttack.evilY)
        //            {
        //                //GenEvilBin();
        //                //evilBinBox1.BeginAnimation(Rectangle.MarginProperty, EvilBinAnim(evilBinBox1.Margin, new Thickness(marginX, marginY + deltaY, 0, 0), 0));
        //                //evilBinBox2.BeginAnimation(Rectangle.MarginProperty, EvilBinAnim(evilBinBox2.Margin, new Thickness(marginX + deltaX, marginY + deltaY, 0, 0), 0));
        //                //evilBinBox1.BeginAnimation(Rectangle.MarginProperty, EvilBinAnim(evilBinBox1.Margin, playerBinBox1.Margin, timeToMove));
        //                //evilBinBox2.BeginAnimation(Rectangle.MarginProperty, EvilBinAnim(evilBinBox2.Margin, playerBinBox2.Margin, timeToMove));
        //                //CollisionEvent();
        //            }
        //            else
        //            {
        //                //GenEvilBin();
        //                //evilBinBox1.BeginAnimation(Rectangle.MarginProperty, EvilBinAnim(evilBinBox1.Margin, new Thickness(marginX, marginY + deltaY, 0, 0), 0));
        //                //evilBinBox2.BeginAnimation(Rectangle.MarginProperty, EvilBinAnim(evilBinBox2.Margin, new Thickness(marginX + deltaX, marginY + deltaY, 0, 0), 0));
        //                //gameStarted = false;
        //            }
        //            GenEvilBin();
        //            evilBinBox1.BeginAnimation(Rectangle.MarginProperty, EvilBinAnim(evilBinBox1.Margin, new Thickness(marginX, marginY + deltaY, 0, 0), 0));
        //            evilBinBox2.BeginAnimation(Rectangle.MarginProperty, EvilBinAnim(evilBinBox2.Margin, new Thickness(marginX + deltaX, marginY + deltaY, 0, 0), 0));
        //            gameStarted = false;
        //            gameFinished = true;
        //        });
        //    });
        //}

        //private void OnKeyDownHandler(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.D && task == "Lab 2: Задание 13")
        //    {
        //        binaryAttack.Plus();
        //        playerBinBox1.Fill = VisualChanger.ChangeColor(binaryAttack.X);
        //        playerBinBox2.Fill = VisualChanger.ChangeColor(binaryAttack.Y);
        //    }
        //    if (e.Key == Key.A && task == "Lab 2: Задание 13")
        //    {
        //        binaryAttack.Minus();
        //        playerBinBox1.Fill = VisualChanger.ChangeColor(binaryAttack.X);
        //        playerBinBox2.Fill = VisualChanger.ChangeColor(binaryAttack.Y);
        //    }
        //    if (e.Key == Key.Enter && task == "Lab 2: Задание 13" && !gameStarted)
        //    {
        //        gameStarted = true;
        //    }
        //    if (e.Key == Key.Escape && task == "Lab 2: Задание 13" && gameStarted)
        //    {
        //        gameStarted = false;
        //    }
        //}

        //BinaryAttack binaryAttack;
        //public Rectangle playerBinBox1;
        //public Rectangle playerBinBox2;
        //public Rectangle evilBinBox1;
        //public Rectangle evilBinBox2;

        //private int timeToMove = 3;
        //private int cubeSize = 20;
        //private double marginX = 100;
        //private double marginY = 200;
        //private double deltaX = 50;
        //private double deltaY = -200;
        //private bool gameStarted = false;
        //private bool gameFinished = false;

        //binaryAttack = new BinaryAttack();


        //playerBinBox1 = InitRectangle("playerBinBox1", cubeSize, cubeSize, marginX, marginY, Brushes.Green);
        //playerBinBox2 = InitRectangle("playerBinBox2", cubeSize, cubeSize, marginX + deltaX, marginY, Brushes.Green);

        //evilBinBox1 = InitRectangle("evilBinBox1", cubeSize, cubeSize, marginX, marginY + deltaY, Brushes.Green);
        //evilBinBox2 = InitRectangle("evilBinBox2", cubeSize, cubeSize, marginX + deltaX, marginY + deltaY, Brushes.Green);
        //GenEvilBin();

        //ThicknessAnimation EvilBinAnim(Thickness from, Thickness to, double fromSeconds)
        //{
        //    ThicknessAnimation evilBinAnim = new ThicknessAnimation();
        //    evilBinAnim.From = from;
        //    evilBinAnim.To = to;

        //    evilBinAnim.Duration = TimeSpan.FromSeconds(fromSeconds);

        //    return evilBinAnim;
        //}

        //public Rectangle InitRectangle(string name, double width, double height, double x, double y, Brush brush)
        //{
        //    Rectangle rectangle = new Rectangle();

        //    rectangle.Name = name;
        //    RegisterName(rectangle.Name, rectangle);

        //    rectangle.Width = width;
        //    rectangle.Height = height;

        //    rectangle.RenderTransform = new TranslateTransform();

        //    //((TranslateTransform)rectangle.RenderTransform).X = x;
        //    //((TranslateTransform)rectangle.RenderTransform).Y = y;

        //    rectangle.Margin = new Thickness(x, y, 0, 0);

        //    rectangle.Fill = brush;

        //    mainGrid.Children.Add(rectangle);

        //    rectangle.Visibility = Visibility.Hidden;

        //    return rectangle;
        //}

        //playerBinBox1.Visibility = (playerBinBox2.Visibility = (evilBinBox1.Visibility = 
        //                                       (evilBinBox2.Visibility = Visibility.Visible)));

        //playerBinBox1.Visibility = (playerBinBox2.Visibility = (evilBinBox1.Visibility =
        //                               (evilBinBox2.Visibility = Visibility.Hidden)));
    }
}
