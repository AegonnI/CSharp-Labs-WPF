using DocumentFormat.OpenXml.Drawing.Diagrams;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace CSharp_Labs_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string task;
        bool isDarkTheme = true; // 0 - light, 1 - dark

        private Matrix A = new Matrix();
        private Matrix B = new Matrix();
        private Matrix C = new Matrix();

        private ExcelDataBase excelDataBase;

        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists("data.dat"))
            {
                StreamReader f = new StreamReader("data.dat");
                task = f.ReadLine();
                try
                {
                    isDarkTheme = bool.Parse(f.ReadLine());
                }
                catch 
                {
                    isDarkTheme = true;
                }
                
                f.Close();
            }
            tasksComboBox.Text = task;
            TaskChooser();
            VisualChanger.ChangeTheme(isDarkTheme, Theme);
        }

        private void Tasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            task = tasksComboBox.SelectedItem.ToString().Substring(38);
            TaskChooser();
        }

        private void Show_Result_Click(object sender, RoutedEventArgs e)
        {
            switch (task)
            {
                case "Lab 1: Задание 1. Методы: 1":
                    ResultText(
                        () => LabChecker.IsDoubleNumber(userValue1.Text) && LabChecker.IsDecimalNumber(userValue1.Text),
                        () => LabMath.fraction(double.Parse(userValue1.Text)).ToString());
                    break;

                case "Lab 1: Задание 1. Методы: 3":
                    ResultText(
                        () => LabChecker.IsCharADigit(userValue1.Text),
                        () => LabMath.charToNum(char.Parse(userValue1.Text)).ToString());
                    break;

                case "Lab 1: Задание 1. Методы: 5":
                    ResultText(
                        () => LabChecker.IsIntNumber(userValue1.Text),
                        () => LabMath.is2Digits(int.Parse(userValue1.Text)).ToString());
                    break;

                case "Lab 1: Задание 1. Методы: 7":
                    ResultText(
                        () => LabChecker.IsIntNumber(userValue1.Text) && LabChecker.IsIntNumber(userValue2.Text) && LabChecker.IsIntNumber(userValue3.Text),
                        () => LabMath.isInRange(int.Parse(userValue1.Text), int.Parse(userValue2.Text), int.Parse(userValue3.Text)).ToString());
                    break;

                case "Lab 1: Задание 1. Методы: 9":
                    ResultText(
                        () => LabChecker.IsIntNumber(userValue1.Text) && LabChecker.IsIntNumber(userValue2.Text) && LabChecker.IsIntNumber(userValue3.Text),
                        () => LabMath.isEqual(int.Parse(userValue1.Text), int.Parse(userValue2.Text), int.Parse(userValue3.Text)).ToString());
                    break;

                case "Lab 1: Задание 2. Условия: 1":
                    ResultText(
                        () => LabChecker.IsIntNumber(userValue1.Text),
                        () => LabMath.abs(int.Parse(userValue1.Text)).ToString());
                    break;

                case "Lab 1: Задание 2. Условия: 3":
                    ResultText(
                        () => LabChecker.IsIntNumber(userValue1.Text),
                        () => LabMath.is35(int.Parse(userValue1.Text)).ToString());
                    break;

                case "Lab 1: Задание 2. Условия: 5":
                    ResultText(
                        () => LabChecker.IsIntNumber(userValue1.Text) && LabChecker.IsIntNumber(userValue2.Text) && LabChecker.IsIntNumber(userValue3.Text),
                        () => LabMath.max3(int.Parse(userValue1.Text), int.Parse(userValue2.Text), int.Parse(userValue3.Text)).ToString());
                    break;

                case "Lab 1: Задание 2. Условия: 7":
                    ResultText(
                        () => LabChecker.IsIntNumber(userValue1.Text) && LabChecker.IsIntNumber(userValue2.Text),
                        () => LabMath.sum2(int.Parse(userValue1.Text), int.Parse(userValue2.Text)).ToString());
                    break;

                case "Lab 1: Задание 2. Условия: 9":
                    ResultText(
                        () => LabChecker.IsIntNumber(userValue1.Text),
                        () => LabMath.day(int.Parse(userValue1.Text)).ToString());
                    break;

                case "Lab 1: Задание 3. Циклы: 1":
                    ResultText(
                        () => LabChecker.IsPosetiveOfZeroInt(userValue1.Text),
                        () => LabMath.listNums(int.Parse(userValue1.Text)).ToString());
                    break;

                case "Lab 1: Задание 3. Циклы: 3":
                    ResultText(
                        () => LabChecker.IsPosetiveOfZeroInt(userValue1.Text),
                        () => LabMath.chet(int.Parse(userValue1.Text)).ToString());
                    break;

                case "Lab 1: Задание 3. Циклы: 5":
                    ResultText(
                        () => LabChecker.IsLongNumber(userValue1.Text),
                        () => LabMath.numLen(long.Parse(userValue1.Text)).ToString());
                    break;

                case "Lab 1: Задание 3. Циклы: 7":
                    ResultText(
                        () => LabChecker.IsPosetiveOfZeroInt(userValue1.Text),
                        () => LabMath.square(int.Parse(userValue1.Text)).ToString());
                    break;

                case "Lab 1: Задание 3. Циклы: 9":
                    ResultText(
                        () => LabChecker.IsPosetiveOfZeroInt(userValue1.Text),
                        () => LabMath.rightTriangle(int.Parse(userValue1.Text)).ToString());
                    break;

                case "Lab 1: Задание 4. Массивы: 1":
                    ResultText(
                        () => LabChecker.IsIntArray(userValue1.Text.Split(' ')) && LabChecker.IsIntNumber(userValue2.Text),
                        () => LabMath.findFirst(LabConverter.StringToIntArr(userValue1.Text.Split(' ')), int.Parse(userValue2.Text)).ToString());
                    break;

                case "Lab 1: Задание 4. Массивы: 3":
                    ResultText(
                        () => LabChecker.IsIntArray(userValue1.Text.Split(' ')),
                        () => LabMath.maxAbs(LabConverter.StringToIntArr(userValue1.Text.Split(' '))).ToString());
                    break;

                case "Lab 1: Задание 4. Массивы: 5":
                    ResultText(
                        () => LabChecker.IndexNotOutside(userValue1.Text.Split(' '), userValue3.Text) && LabChecker.IsIntArray(userValue2.Text.Split(' ')),
                        () => LabConverter.IntArrToText(LabMath.add(LabConverter.StringToIntArr(userValue1.Text.Split(' ')), LabConverter.StringToIntArr(userValue2.Text.Split(' ')), int.Parse(userValue3.Text))).ToString());
                    break;

                case "Lab 1: Задание 4. Массивы: 7":
                    ResultText(
                        () => LabChecker.IsIntArray(userValue1.Text.Split(' ')),
                        () => LabConverter.IntArrToText(LabMath.reverseBack(LabConverter.StringToIntArr(userValue1.Text.Split(' ')))).ToString());
                    break;

                case "Lab 1: Задание 4. Массивы: 9":
                    ResultText(
                        () => LabChecker.IsIntArray(userValue1.Text.Split(' ')) && LabChecker.IsIntNumber(userValue2.Text),
                        () => LabConverter.IntArrToText(LabMath.findAll(LabConverter.StringToIntArr(userValue1.Text.Split(' ')), int.Parse(userValue2.Text))).ToString());
                    break;

                case "Lab 2: Задание 13":
                    if (LabChecker.IsBool(userValue1.Text) && LabChecker.IsBool(userValue2.Text))
                    {
                        Lab2v13 bools = new Lab2v13(LabConverter.StringToBool(userValue1.Text), LabConverter.StringToBool(userValue2.Text));

                        resultLabel.Content = "Implication = " + bools.Implication().ToString();
                        resultLabel.Content += "\nToSring = " + bools.ToString();

                        Lab2v13Extended boolsEx = new Lab2v13Extended(bools, LabConverter.StringToBool(userValue3.Text));
                        
                        resultLabel.Content += "\n\nImplication2 = " + boolsEx.ExtendedImplication().ToString();
                        resultLabel.Content += "\nToSring2 = " + boolsEx.ToString();
                    }
                    else
                    {
                        resultLabel.Content = "Incorrect input, try again!";
                    }
                    break;

                case "Lab 3: Задание 1":
                    if (LabChecker.IsUint(userValue1.Text, 9999999) && LabChecker.IsByte(userValue2.Text, 99) && LabChecker.IsUint(userValue3.Text, 9999999))
                    {
                        Money money = new Money(uint.Parse(userValue1.Text), byte.Parse(userValue2.Text));

                        resultLabel.Content = "ToString: " + money.ToString();

                        resultLabel.Content += "\noverload '+': " + (money + uint.Parse(userValue3.Text)).ToString();
                        resultLabel.Content += "\noverload '-' (Money - m): " + (money - uint.Parse(userValue3.Text)).ToString();
                        resultLabel.Content += "\noverload '-' (m - Money): " + (uint.Parse(userValue3.Text) - money).ToString();
                        {
                            Random rand = new Random();
                            Money money2 = new Money((uint)rand.Next(0, 100), (byte)rand.Next(0, 99));
                            resultLabel.Content += $"\noverload '-' (Money1 - Money2({money2.Rubles}, {money2.Kopeks})): " + (money - money2).ToString();
                        }                        
                        resultLabel.Content += "\noverload '++': " + (++money).ToString();
                        resultLabel.Content += "\noverload '--': " + (--money).ToString();
                        resultLabel.Content += "\nexplicit uint: " + ((uint)money).ToString();
                        resultLabel.Content += "\nimplicit bool: " + (money == true).ToString();
                    }
                    else
                    {
                        resultLabel.Content = "Incorrect input, try again!";
                    }
                    break;

                case "Lab 4: Задания 1, 3":
                    try
                    {
                        if (!ChooseMatrixA.IsEnabled)
                        {
                            A = VisualChanger.CreateMatrix(userValue1, userValue2, userValue3, ChooseConstructor1, ChooseConstructor2, ChooseConstructor3);
                        }
                        else if (!ChooseMatrixB.IsEnabled)
                        {
                            B = VisualChanger.CreateMatrix(userValue1, userValue2, userValue3, ChooseConstructor1, ChooseConstructor2, ChooseConstructor3);
                        }
                        else
                        {
                            C = VisualChanger.CreateMatrix(userValue1, userValue2, userValue3, ChooseConstructor1, ChooseConstructor2, ChooseConstructor3);
                        }
                        resultLabel.Content = Matrix.MatrixOutput("A B C".Split(' '), A, B, C);
                    }
                    catch
                    {
                        resultLabel.Content = "Incorrect input, try again!";
                    }
                    break;

                case "Lab 4: Задания 2":
                    if (LabChecker.IsPosetiveInt(userValue1.Text) && 
                        LabChecker.IsIntArray(userValue2.Text.Split(' ')) && 
                        LabChecker.IsOneZeroArray(userValue2.Text.Split(' ')) &&
                        userValue2.Text.Split(' ').Length == 2*int.Parse(userValue1.Text))
                    {
                        A = new Matrix(LabConverter.StringToIntArr(userValue2.Text.Split(' ')), 2);
                        resultLabel.Content = Matrix.WhichDeputiesHaveMore(A);
                    }
                    else
                    {
                        resultLabel.Content = "Incorrect input, try again!";
                    }
                    break;

                case "Lab 4: Задание 4":
                    if (LabChecker.IsPosetiveInt(userValue1.Text) && LabChecker.IsInt(userValue2.Text))
                    {
                        if (userValue3.Text == "")
                        {
                            LabFiles.CreateBinaryFile("lab4-source.bin", int.Parse(userValue1.Text), int.Parse(userValue2.Text));
                        }
                        else
                        {
                            LabFiles.CreateBinaryFile("lab4-source.bin", int.Parse(userValue1.Text), int.Parse(userValue2.Text), int.Parse(userValue3.Text));
                        }
                        
                        LabFiles.RemoveDuplicates("lab4-source.bin", "lab4-new.bin");
                        resultLabel.Content = "Source file: " +LabFiles.BinaryFileToString("lab4-source.bin", "\n", " ");
                        resultLabel.Content += "\n   New file: " + LabFiles.BinaryFileToString("lab4-new.bin", "\n", " ");
                    }
                    else
                    {
                        resultLabel.Content = "Incorrect input, try again!";
                    }
                    break;

                case "Lab 4: Задание 5":
                    if (userValue1.Text != "")
                        try
                        {
                            LabFiles.CreateFileWithToys("lab5-source.bin", userValue1.Text.Split(' '));
                            resultLabel.Content = "Source file:\n" + LabFiles.BinaryFileToString("lab5-source.bin", "\n", " ",typeof(string), typeof(int), typeof(int), typeof(int));
                            resultLabel.Content += "\n\nMost Expensive in the Range: " + LabFiles.MostExpensiveInTheRange("lab5-source.bin");
                        }
                        catch
                        {
                            resultLabel.Content = "Incorrect input, try again!";
                        }
                    else
                    {
                        resultLabel.Content = "Toys are out, come back later!";
                    }
                    break;

                case "Lab 4: Задание 6":
                    if (LabChecker.IsDigit(userValue1.Text))
                    {
                        LabFiles.CreateRandomFile("lab4-6.txt", 10, 100);

                        resultLabel.Content = "Source file: " + LabFiles.ReadFile("lab4-6.txt");
                        resultLabel.Content += "\nSum: " + LabFiles.FindSumOfElemsWithGivenEnding("lab4-6.txt", int.Parse(userValue1.Text));
                    }
                    else
                    {
                        resultLabel.Content = "Incorrect input, try again!";
                    }
                    break;

                case "Lab 4: Задание 7":
                    try
                    {
                        LabFiles.CreateRandomOneLineFile("lab4-7.txt", 10, 100);

                        resultLabel.Content = "Source file: " + LabFiles.ReadFile("lab4-7.txt");
                        resultLabel.Content += "\nSum: " + LabFiles.DiffBetweenFirstAndMin("lab4-7.txt");
                    }
                    catch 
                    {
                        resultLabel.Content = "Error!";
                    }
                    break;

                case "Lab 4: Задание 8":
                    try
                    {
                        LabFiles.WriteWithoutPunctuation("lab4-8-source.txt", "lab4-8-new.txt");
                        resultLabel.Content = "Source file:\n" + LabFiles.ReadFile("lab4-8-source.txt", "\n");
                        resultLabel.Content += "\n\nPunctuation:\n" + LabFiles.ReadFile("lab4-8-new.txt", "\n");
                    }
                    catch
                    {
                        resultLabel.Content = "Incorrect input, try again!";
                    }
                    break;

                case "Lab 5: Задание 1":
                    try
                    {
                        List<string> L1 = new List<string>(userValue1.Text.Split(' '));
                        List<string> L2 = new List<string>(userValue2.Text.Split(' '));
                        resultLabel.Content = string.Join(" ", Lab5.SymmetricalDifference(L1, L2));
                    }
                    catch
                    {
                        resultLabel.Content = "Incorrect input, try again!";
                    }
                    break;

                case "Lab 5: Задание 2":
                    try
                    {
                        LinkedList<string> L = new LinkedList<string>(userValue1.Text.Split(' '));
                        resultLabel.Content = string.Join(" ", Lab5.DeleteAllBetweenMinMax(L));
                    }
                    catch
                    {
                        resultLabel.Content = "Incorrect input, try again!";
                    }
                    break;

                case "Lab 5: Задание 3":
                    try
                    {
                        HashSet<HashSet<string>> stats = Lab5.CreateShowStat("ShowsNames.txt", int.Parse(userValue1.Text));
                        resultLabel.Content = Lab5.DouHashSetToString(stats);
                        resultLabel.Content += "\n\n" + Lab5.ShowRating("ShowsNames.txt", Lab5.CreateShowStat("ShowsNames.txt", int.Parse(userValue1.Text)));
                    }
                    catch
                    {
                        resultLabel.Content = "Incorrect input, try again!";
                    }
                    break;

                case "Lab 5: Задание 4":
                    try
                    {
                        resultLabel.Content = string.Join(" ", Lab5.DigintsInText("Lab5-4.txt"));                 
                    }
                    catch
                    {
                        //resultLabel.Content = E;
                        resultLabel.Content = "problems with the file";
                    }
                    break;

                case "Lab 5: Задание 5":
                    try
                    {
                        resultLabel.Content = Lab5.GetOldestHuman("Lab5-5-Persons.txt");
                    }
                    catch
                    {
                        resultLabel.Content = "Incorrect input, try again!";
                    }
                    break;

                case "Lab 5: Задание 6":
                    try
                    {
                        Lab5.CreateToysFile("lab5-6.xml", "A", "B", "C", "D", "E");
                        List<Lab5.Toy> toys = Lab5.FileToValue<List<Lab5.Toy>>("lab5-6.xml");
                        resultLabel.Content = "";
                        foreach (Lab5.Toy item in toys)
                        {
                            resultLabel.Content += item.name + " " + item.price + " " + item.minAge + " " + item.maxAge + '\n';
                        }
                        resultLabel.Content += '\n' + Lab5.RichestToyForKids("lab5-6.xml");
                    }
                    catch
                    {
                        resultLabel.Content = "Incorrect input, try again!";
                    }
                    break;

                case "Lab 6":
                    DelElem.IsEnabled = false;
                    CorrectElem.IsEnabled = true;
                    AddElem.IsEnabled = true;
                    userValue1.IsEnabled = true;
                    ChooseMatrixA.IsEnabled = false;
                    ChooseMatrixB.IsEnabled = true;
                    ChooseMatrixC.IsEnabled = true;
                    ShowDataBase.IsEnabled = true;
                    try
                    {
                        excelDataBase = new ExcelDataBase(Path.GetFullPath(@"..\..\data\LR6-var13.xls"), Path.GetFullPath(@"..\..\data\LR6-var13.xlsx"));
                    }
                    catch(Exception ex)
                    {
                        resultLabel.Content = "Incorrect input, try again!";
                        resultLabel.Content = ex.Message;
                    }
                    break;

                default:
                    break;
            }
        }

        void TaskChanger(string taskName, string taskText, string entryMessage, string v1 = "", string v2 = "", string v3 = "")
        {
            taskNameLabel.Content = taskName;
            taskTextLabel.Content = taskText;
            entryMessageLabel.Content = entryMessage;
            ChangeInputField(v1, v2, v3);

            VisualChanger.ChangeVisible(false, ChooseConstructor1, ChooseConstructor2, ChooseConstructor3,
                                               ChooseMatrixA, ChooseMatrixB, ChooseMatrixC, calculateButton, secondShowResultButton);
        }

        void TaskChanger(string taskName, string taskText, string entryMessage, uint type = 0, string v1 = "", string v2 = "", string v3 = "")
        {
            taskNameLabel.Content = taskName;
            taskTextLabel.Content = taskText;
            entryMessageLabel.Content = entryMessage;
            ChangeInputField(v1, v2, v3);

            VisualChanger.ChangeVisible(false, ChooseConstructor1, ChooseConstructor2, ChooseConstructor3,
                                   ChooseMatrixA, ChooseMatrixB, ChooseMatrixC, calculateButton, secondShowResultButton);
            showResultButton.Content = "ShowResult";
            if (type == 1)
            {
                ChooseMatrixA.Content = "A";
                ChooseMatrixB.Content = "B";
                ChooseMatrixC.Content = "C";
                VisualChanger.ChangeVisible(true, ChooseConstructor1, ChooseConstructor2, ChooseConstructor3, 
                                                  ChooseMatrixA, ChooseMatrixB, ChooseMatrixC, calculateButton);
            }
            else if (type == 2)
            {            
                VisualChanger.ChangeVisible(false, ChooseConstructor1, ChooseConstructor2, ChooseConstructor3,
                                                   ChooseMatrixA, ChooseMatrixB, ChooseMatrixC, calculateButton);
            }
            else if (type == 3)
            {
                showResultButton.Content = "Считать базу данных";
                ChooseMatrixA.Content = "Счета";
                ChooseMatrixB.Content = "Курс Валют";
                ChooseMatrixC.Content = "Поступления";
                VisualChanger.ChangeVisible(true, ChooseMatrixA, ChooseMatrixB, ChooseMatrixC);
            }
            else
            {
                VisualChanger.ChangeVisible(false, ChooseConstructor1, ChooseConstructor2, ChooseConstructor3,
                                       ChooseMatrixA, ChooseMatrixB, ChooseMatrixC, calculateButton, secondShowResultButton);
            }
        }

        void ChangeInputField(string v1 = "", string v2 = "", string v3 = "")
        {
            valueName1.Content = v1;
            valueName2.Content = v2;
            valueName3.Content = v3;

            userValue1.Visibility = VisualChanger.ChangeVisible(v1 != "");
            userValue2.Visibility = VisualChanger.ChangeVisible(v2 != "");
            userValue3.Visibility = VisualChanger.ChangeVisible(v3 != "");

            resultLabel.RenderTransform = new TranslateTransform();
            if (v3 != "")
            {
                ((TranslateTransform)resultLabel.RenderTransform).Y = userValue3.Margin.Top + 23 - resultLabel.Margin.Top;
            }
            else if (v2 != "")
            {
                ((TranslateTransform)resultLabel.RenderTransform).Y = userValue2.Margin.Top + 23 - resultLabel.Margin.Top;
            }
            else if (v1 != "")
            {
                ((TranslateTransform)resultLabel.RenderTransform).Y = userValue1.Margin.Top + 23 - resultLabel.Margin.Top;
            }
        }

        void ResultText(Func<bool> checkFunc, Func<string> resultFunc)
        {
            resultLabel.Content = LabMath.ResultText(
                () => checkFunc(),
                () => resultFunc());
        }

        void DataWindow_Closing(object sender, CancelEventArgs e)
        {
            StreamWriter f = new StreamWriter("data.dat");
            f.WriteLine(task);
            f.WriteLine(isDarkTheme);
            f.Close();
        }

        void TaskChooser()
        {            
            resultLabel.Content = "";
            userValue1.Text = "";
            userValue2.Text = "";
            userValue3.Text = "";

            userValue1.IsEnabled = true;
            ChooseMatrixB.IsEnabled = true;
            ChooseMatrixC.IsEnabled = true;

            switch (task)
            {
                case "Lab 1: Задание 1. Методы: 1":
                    TaskChanger("Задание 1. Методы",
                        "Дробная часть." +
                        "\r\nДана сигнатура метода: public double fraction (double x);" +
                        "\r\nНеобходимо реализовать метод таким образом, чтобы он возвращал только" +
                        "\r\nдробную часть числа х. Подсказка: вещественное число может быть" +
                        "\r\nпреобразовано к целому путем отбрасывания дробной части." +
                        "\r\nПример:" +
                        "\r\nx=5,25" +
                        "\r\nрезультат: 0,25" +
                        "\r\n",
                        "Введите вещественное число:",
                        "x = ");
                    break;

                case "Lab 1: Задание 1. Методы: 3":
                    TaskChanger("Задание 1. Методы",
                         "Букву в число." +
                         "\r\nДана сигнатура метода: public int charToNum (char x);" +
                         "\r\nМетод принимает символ х, который представляет собой один из “0 1 2 3 4 5 6 7" +
                         "\r\n8 9”. Необходимо реализовать метод таким образом, чтобы он преобразовывал" +
                         "\r\nсимвол в соответствующее число. Подсказка: код символа ‘0’ — это число 48." +
                         "\r\nПример:" +
                         "\r\nx=’3’" +
                         "\r\nрезультат: 3" +
                         "\r\n",
                         "Введите одно число из \"0 1 2 3 4 5 6 7 8 9\":",
                         "x = ");
                    break;

                case "Lab 1: Задание 1. Методы: 5":
                    TaskChanger("Задание 1. Методы",
                         "Двузначное." +
                         "\r\nДана сигнатура метода: public bool is2Digits (int x);" +
                         "\r\nНеобходимо реализовать метод таким образом, чтобы он принимал число x и" +
                         "\r\nвозвращал true, если оно двузначное." +
                         "\r\nПример 1:" +
                         "\r\nx=32" +
                         "\r\nрезультат: true" +
                         "\r\nПример 2:" +
                         "\r\nx=516" +
                         "\r\nрезультат: false" +
                         "\r\n",
                         "Введите число",
                         "x = ");
                    break;

                case "Lab 1: Задание 1. Методы: 7":
                    TaskChanger("Задание 1. Методы",
                         "Диапазон." +
                         "\r\nДана сигнатура метода: public bool isInRange (int a, int b, int num);" +
                         "\r\nМетод принимает левую и правую границу (a и b) некоторого числового" +
                         "\r\nдиапазона. Необходимо реализовать метод таким образом, чтобы он возвращал" +
                         "\r\ntrue, если num входит в указанный диапазон (включая границы). Обратите" +
                         "\r\nвнимание, что отношение a и b заранее неизвестно (неясно кто из них больше, а" +
                         "\r\nкто меньше)" +
                         "\r\nПример 1:" +
                         "\r\na=5 b=1 num=3" +
                         "\r\nрезультат: true" +
                         "\r\nПример 2:" +
                         "\r\na=2 b=15 num=33" +
                         "\r\nрезультат: false" +
                         "\r\n",
                         "Введите числа",
                         "a = ", "b = ", "num = ");
                    break;

                case "Lab 1: Задание 1. Методы: 9":
                    TaskChanger("Задание 1. Методы",
                         "Равенство." +
                         "\r\nДана сигнатура метода: public bool isEqual(int a, int b, int c);" +
                         "\r\nНеобходимо реализовать метод таким образом, чтобы он возвращал true, если" +
                         "\r\nвсе три полученных методом числа равны" +
                         "\r\nПример 1:" +
                         "\r\na=3 b=3 с=3" +
                         "\r\nрезультат: true" +
                         "\r\nПример 2:" +
                         "\r\na=2 b=15 с=2" +
                         "\r\nрезультат: false",
                         "Введите числа",
                         "a = ", "b = ", "c = ");
                    break;

                case "Lab 1: Задание 2. Условия: 1":
                    TaskChanger("Задание 2. Условия",
                         "Модуль числа." +
                         "\r\nДана сигнатура метода: public int abs (int x);" +
                         "\r\nНеобходимо реализовать метод таким образом, чтобы он возвращал модуль" +
                         "\r\nчисла х (если оно было положительным, то таким и остается, если он было" +
                         "\r\nотрицательным – то необходимо вернуть его без знака минус)." +
                         "\r\nПример 1:" +
                         "\r\nx=5" +
                         "\r\nрезультат: 5" +
                         "\r\nПример 2:" +
                         "\r\nx=-3" +
                         "\r\nрезультат: 3",
                         "Введите число",
                         "x = ");
                    break;

                case "Lab 1: Задание 2. Условия: 3":
                    TaskChanger("Задание 2. Условия",
                         "Тридцать пять." +
                         "\r\nДана сигнатура метода: public bool is35 (int x);" +
                         "\r\nНеобходимо реализовать метод таким образом, чтобы он возвращал true, если" +
                         "\r\nчисло x делится нацело на 3 или 5. При этом, если оно делится и на 3, и на 5, то" +
                         "\r\nвернуть надо false. Подсказка: оператор % позволяет получить остаток от" +
                         "\r\nделения." +
                         "\r\nПример 1:" +
                         "\r\nx=5" +
                         "\r\nрезультат: true" +
                         "\r\nПример 2:" +
                         "\r\nx=8" +
                         "\r\nрезультат: false" +
                         "\r\nПример 3:" +
                         "\r\nx=15" +
                         "\r\nрезультат: false",
                         "Введите число",
                         "x = ");
                    break;

                case "Lab 1: Задание 2. Условия: 5":
                    TaskChanger("Задание 2. Условия",

                         "Тройной максимум." +
                         "\r\nДана сигнатура метода: public int max3 (int x, int y, int z);" +
                         "\r\nНеобходимо реализовать метод таким образом, чтобы он возвращал" +
                         "\r\nмаксимальное из трех полученных методом чисел. Подсказка: идеальное" +
                         "\r\nрешение включает всего две инструкции if и не содержит вложенных if." +
                         "\r\nПример 1:" +
                         "\r\nx=5 y=7 z=7" +
                         "\r\nрезультат: 7" +
                         "\r\nПример 2:" +
                         "\r\nx=8 y=-1 z=4" +
                         "\r\nрезультат: 8",

                         "Введите числа",

                         "x = ", "y = ", "z = ");
                    break;

                case "Lab 1: Задание 2. Условия: 7":
                    TaskChanger("Задание 2. Условия",

                         "Двойная сумма." +
                         "\r\nДана сигнатура метода: public int sum2 (int x, int y);" +
                         "\r\nНеобходимо реализовать метод таким образом, чтобы он возвращал сумму" +
                         "\r\nчисел x и y. Однако, если сумма попадает в диапазон от 10 до 19, то надо вернуть" +
                         "\r\nчисло 20." +
                         "\r\nПример 1:" +
                         "\r\nx=5 y=7" +
                         "\r\nрезультат: 20" +
                         "\r\nПример 2:" +
                         "\r\nx=8 y=-1" +
                         "\r\nрезультат: 7",

                         "Введите числа",

                         "x = ", "y = ");
                    break;

                case "Lab 1: Задание 2. Условия: 9":
                    TaskChanger("Задание 2. Условия",

                         "День недели." +
                         "\r\nДана сигнатура метода: public String day (int x);" +
                         "\r\nМетод принимает число x, обозначающее день недели. Необходимо реализовать" +
                         "\r\nметод таким образом, чтобы он возвращал строку, которая будет обозначать" +
                         "\r\nтекущий день недели, где 1- это понедельник, а 7 – воскресенье. Если число не" +
                         "\r\nот 1 до 7 то верните текст “это не день недели”. Вместо if в данной задаче" +
                         "\r\nиспользуйте switch." +
                         "\r\nПример:" +
                         "\r\nx=5" +
                         "\r\nрезультат: “пятница”",

                         "Введите число",

                         "x = ");
                    break;

                case "Lab 1: Задание 3. Циклы: 1":
                    TaskChanger("Задание 3. Циклы",

                         "Числа подряд." +
                         "\r\nДана сигнатура метода: public String listNums (int x);" +
                         "\r\nНеобходимо реализовать метод таким образом, чтобы он возвращал строку, в" +
                         "\r\nкоторой будут записаны все числа от 0 до x (включительно)." +
                         "\r\nПример:" +
                         "\r\nx=5" +
                         "\r\nрезультат: “0 1 2 3 4 5”",

                         "Введите число",

                         "x = ");
                    break;

                case "Lab 1: Задание 3. Циклы: 3":
                    TaskChanger("Задание 3. Циклы",

                         "Четные числа." +
                         "\r\nДана сигнатура метода: public String chet (int x);" +
                         "\r\nНеобходимо реализовать метод таким образом, чтобы он возвращал строку, в" +
                         "\r\nкоторой будут записаны все четные числа от 0 до x (включительно). Подсказа" +
                         "\r\nдля обеспечения качества кода: инструкцию if использовать не следует." +
                         "\r\nПример:" +
                         "\r\nx=9" +
                         "\r\nрезультат: “0 2 4 6 8”",

                         "Введите число",

                         "x = ");
                    break;

                case "Lab 1: Задание 3. Циклы: 5":
                    TaskChanger("Задание 3. Циклы",

                         "Длина числа." +
                         "\r\nДана сигнатура метода: public int numLen (long x);" +
                         "\r\nНеобходимо реализовать метод таким образом, чтобы он возвращал количество" +
                         "\r\nзнаков в числе x." +
                         "\r\nПодсказка:" +
                         "\r\nInt у=123/10; // у будет иметь значение 12" +
                         "\r\nПример:" +
                         "\r\nx=12567" +
                         "\r\nрезультат: 5",

                         "Введите число",

                         "x = ");
                    break;

                case "Lab 1: Задание 3. Циклы: 7":
                    TaskChanger("Задание 3. Циклы",

                         "Квадрат." +
                         "\r\nДана сигнатура метода: public void square (int x);" +
                         "\r\nНеобходимо реализовать метод таким образом, чтобы он выводил на экран" +
                         "\r\nквадрат из символов ‘*’ размером х, у которого х символов в ряд и х символов в" +
                         "\r\nвысоту." +
                         "\r\nПример 1:" +
                         "\r\nx=2" +
                         "\r\nрезультат:" +
                         "\r\n**" +
                         "\r\n**" +
                         "\r\nПример 2:" +
                         "\r\nx=4" +
                         "\r\nрезультат:" +
                         "\r\n****" +
                         "\r\n****" +
                         "\r\n****" +
                         "\r\n****",

                         "Введите число",

                         "x = ");
                    break;

                case "Lab 1: Задание 3. Циклы: 9":
                    TaskChanger("Задание 3. Циклы",

                         "Правый треугольник." +
                         "\r\nДана сигнатура метода: public void rightTriangle (int x);" +
                         "\r\nНеобходимо реализовать метод таким образом, чтобы он выводил на экран" +
                         "\r\nтреугольник из символов ‘*’ у которого х символов в высоту, а количество" +
                         "\r\nсимволов в ряду совпадает с номером строки, при этом треугольник выровнен" +
                         "\r\nпо правому краю. Подсказка: перед символами ‘*’ следует выводить" +
                         "\r\nнеобходимое количество пробелов." +
                         "\r\nПример 1:" +
                         "\r\nx=3" +
                         "\r\nрезультат:" +
                         "\r\n *" +
                         "\r\n **" +
                         "\r\n***" +
                         "\r\nПример 2:" +
                         "\r\nx=4" +
                         "\r\nрезультат:" +
                         "\r\n *" +
                         "\r\n **" +
                         "\r\n ***" +
                         "\r\n****",

                         "Введите число",

                         "x = ");
                    break;

                case "Lab 1: Задание 4. Массивы: 1":
                    TaskChanger("Задание 4. Массивы",

                         "Поиск первого значения." +
                         "\r\nДана сигнатура метода: public int findFirst (int[] arr, int x);" +
                         "\r\nНеобходимо реализовать метод таким образом, чтобы он возвращал индекс" +
                         "\r\nпервого вхождения числа x в массив arr. Если число не входит в массив –" +
                         "\r\nвозвращается -1." +
                         "\r\nПример:" +
                         "\r\narr=[1,2,3,4,2,2,5]" +
                         "\r\nx=2" +
                         "\r\nрезультат: 1",

                         "Введите числа массива(через пробел) и число",

                         "arr = ", "x = ");
                    break;

                case "Lab 1: Задание 4. Массивы: 3":
                    TaskChanger("Задание 4. Массивы",

                         "Поиск максимального." +
                         "\r\nДана сигнатура метода: public int maxAbs (int[] arr);" +
                         "\r\nНеобходимо реализовать метод таким образом, чтобы он возвращал" +
                         "\r\nнаибольшее по модулю (то есть без учета знака) значение массива arr." +
                         "\r\nПример:" +
                         "\r\narr=[1,-2,-7,4,2,2,5]" +
                         "\r\nрезультат: -7",

                         "Введите числа массива(через пробел)",

                         "arr = ");
                    break;

                case "Lab 1: Задание 4. Массивы: 5":
                    TaskChanger("Задание 4. Массивы",

                         "Добавление массива в массив." +
                         "\r\nДана сигнатура метода: public int[] add (int[] arr, int[] ins, int pos);" +
                         "\r\nНеобходимо реализовать метод таким образом, чтобы он возвращал новый" +
                         "\r\nмассив, который будет содержать все элементы массива arr, однако в позицию" +
                         "\r\npos будут вставлены значения массива ins." +
                         "\r\nПример:" +
                         "\r\narr=[1,2,3,4,5]" +
                         "\r\nins=[7,8,9]" +
                         "\r\npos=3" +
                         "\r\nрезультат: [1,2,3,7,8,9,4,5]",

                         "Введите числа массивов(через пробел) и число",

                         "arr = ", "ins = ", "pos = ");
                    break;

                case "Lab 1: Задание 4. Массивы: 7":
                    TaskChanger("Задание 4. Массивы",

                         "Возвратный реверс." +
                         "\r\nДана сигнатура метода: public int[] reverseBack (int[] arr);" +
                         "\r\nНеобходимо реализовать метод таким образом, чтобы он возвращал новый" +
                         "\r\nмассив, в котором значения массива arr записаны задом наперед." +
                         "\r\nПример:" +
                         "\r\narr=[1,2,3,4,5]" +
                         "\r\nрезультат: [5,4,3,2,1]" +
                         "\r\n",

                         "Введите числа массив(через пробел)",

                         "arr = ");
                    break;

                case "Lab 1: Задание 4. Массивы: 9":
                    TaskChanger("Задание 4. Массивы",

                         "Все вхождения." +
                         "\r\nДана сигнатура метода: public int[] findAll (int[] arr, int x);" +
                         "\r\nНеобходимо реализовать метод таким образом, чтобы он возвращал новый" +
                         "\r\nмассив, в котором записаны индексы всех вхождений числа x в массив arr." +
                         "\r\nПример:" +
                         "\r\narr=[1,2,3,8,2,2,9]" +
                         "\r\nx=2" +
                         "\r\nрезультат: [1,4,5]",

                         "Введите числа массив(через пробел)",

                         "arr = ", "x = ");
                    break;

                case "Lab 2: Задание 13":
                    TaskChanger("Задание 13",

                         "Разработать класс с двумя логическими полями. Создать конструктор" +
                         "\r\nкопирования. Разработать метод, вычисляющий импликацию полей." +
                         "\r\nПерегрузить метод ToString() для формирования строки из полей класса." +
                         "\r\nРеализовать дочерний класс (его содержание предложить самостоятельно" +
                         "\r\nи описать в решении: какой содержательный смысл имеют поля;" +
                         "\r\nреализовать конструкторы; предложить и реализовать 2-3 метода)." +
                         "\r\nПротестировать все конструкторы и другие методы базового и дочернего" +
                         "\r\nклассов.",

                         "Введите булевые значения",

                         "X = ", "Y = ", "Z = ");
                    break;

                case "Lab 3: Задание 1":
                    TaskChanger("Задание 1",

                         "Класс Money" +
                         "\r\n\r\nПоля uint rubles, byte kopeks" +
                         "\r\n\r\nВычитание копеек (uint) из" +
                         "\r\nобъекта типа Money(учесть, что" +
                         "\r\nденежная величина не может" +
                         "\r\nбыть меньше 0).Результат" +
                         "\r\nдолжен быть типа Money." +
                         "Унарные операции:" +
                         "\r\n-- вычитание копейки из объекта типа Money" +
                         "\r\n++ добавление копейки к объекту типа Money" +
                         "\r\nОперации приведения типа:" +
                         "\r\nuint (явная) результатом является количество рублей" +
                         "\r\n(копейки отбрасываются);" +
                         "\r\nbool (неявная) результатом является true, если денежная" +
                         "\r\nсумма не равна 0." +
                         "\r\nБинарные операции:" +
                         "\r\n- Money m, беззнаковое целое число (лево- и" +
                         "\r\nправосторонние операции). Число обозначает копейки" +
                         "\r\n- Money m1, Money m2 вычитание денежных сумм",

                         "Введите неотрицательные значения \nрублей и копеек(до 100)",

                         "rubles = ", "kopeks = ", "minus kopeks = ");
                    break;

                case "Lab 4: Задания 1, 3":
                    TaskChanger("Задание 1",

                         "Задания 1, 2 и 3 выполнить в виде методов одного класса." +
                         "\r\nЗадание 1 реализовать в виде конструкторов " +
                         "\r\n(кроме них, могут быть и другие конструкторы). " +
                         "\r\nКласс содержит единственное поле – двумерный массив." +
                         "\r\nВ задании 3 перегрузить необходимые операторы и " +
                         "\r\nпосчитать значение матричного выражения" +
                         "\r\n(решение без перегрузки не принимается). " +
                         "\r\nПерегрузить метод ToString() — сформировать строку из" +
                         "\r\nдвумерного массива для отображения его на экране в виде таблицы. " +
                         "\r\nПриложить в отчет скриншот" +
                         "\r\nпроверки на онлайн-калькуляторе, чтобы показать," +
                         "\r\nчто выражение посчитано верно. ",

                         "Введите размеры и саму матрицу\n(элеметы идут через пробел)",
                         1,

                         "n = ", "m = ", "arr = ");
                    break;

                case "Lab 4: Задания 2":
                    TaskChanger("Задание 2",

                         "В двумерном массиве содержатся результаты " +
                         "\r\nдвух голосований п депутатов. " +
                         "\r\nПри голосовании" +
                         "\r\nтребовалось ответить \"Да\" или \"Нет\". " +
                         "\r\nПодсчитайте каких депутатов больше: тех, кто оба раза" +
                         "\r\nпроголосовал одинаково, или тех кто изменил свое решение.",

                         "",

                         "number of deputies = ", "arr(1 or 0) = ");
                    break;

                case "Lab 4: Задание 4":
                    TaskChanger("Задание 4",

                         "Из исходного файла получить новый файл," +
                         "\r\nисключив повторные вхождения чисел." +
                         "\r\nПорядок следования чисел сохранить.",

                         "",

                         "n = ", "maxValue = ", "minValue = ");
                    break;

                case "Lab 4: Задание 5":
                    TaskChanger("Задание 5",

                         "Файл содержит сведения об игрушках: " +
                         "\r\nназвание игрушки, ее стоимость в рублях и возрастные" +
                         "\r\nграницы" +
                         "\r\n(например, игрушка может предназначаться для детей от двух до пяти лет)." +
                         "\r\nПолучить название самой дорогой игрушки, подходящей детям двух-трех лет.",

                         "",

                         "toys names = ");
                    break;

                case "Lab 4: Задание 6":
                    TaskChanger("Задание 6",

                         "Найти сумму элементов, " +
                         "\r\nоканчивающихся на заданную цифру" +
                         "\r\nВ задании 6 в текстовом файле хранятся целые числа по одному в строке," +
                         "\r\nисходный файл необходимо заполнить случайными данными, " +
                         "\r\nзаполнение организовать отдельным методом.",

                         "",

                         "digit = ");
                    break;

                case "Lab 4: Задание 7":
                    TaskChanger("Задание 7",

                         "Решить задачу с использованием структуры «текстовый файл»" +
                         "\r\nНайти разность первого и минимального элементов." +
                         "\r\nВ задании 7 в текстовом файле хранятся целые числа по несколько в строке," +
                         "\r\nисходный файл необходимо заполнить случайными данными, " +
                         "\r\nзаполнение организовать отдельным методом.",

                         "",

                         0);
                    break;

                case "Lab 4: Задание 8":
                    TaskChanger("Задание 8",

                         "Текстовый файл" +
                         "\r\nПереписать в другой файл строки, в которых нет знаков препинания" +
                         "\r\nВ задании 8 в текстовом файле хранится текст.",

                         "", 
                         
                         0);
                    break;

                case "Lab 5: Задание 1":
                    TaskChanger("Задание 1",

                         "Решить задачу, используя класс List" +
                         "\r\nСоставить программу, которая формирует список L" +
                         "\r\nвключив в него по одному разу элементы," +
                         "\r\nкоторые входят в один из списков L1 и L2," +
                         "\r\nно в то же время не входит в другой из них",

                         "Введите два списка",

                         "L1 = ", "L2 = ");
                    break;

                case "Lab 5: Задание 2":
                    TaskChanger("Задание 2",

                         "Решить задачу, используя класс LinkedList" +
                         "\r\nудалить все элементы " +
                         "\r\nмежду минимальным и максимальным элементами;",

                         "Введите список",

                         "L = ");
                    break;

                case "Lab 5: Задание 3":
                    TaskChanger("Задание 3",

                         "Решить задачу, используя класс HashSet" +
                         "\r\nЕсть перечень названий телевизионных шоу." +
                         "\r\nОпределить для каждого наименования шоу," +
                         "\r\nкакие из них нравятся всем n телезрителям," +
                         "\r\nкакие — некоторым из телезрителей," +
                         "\r\nи какие — никому из телезрителей.",

                         "Введите список",

                         2,
                         "n = ");
                    break;

                case "Lab 5: Задание 4":
                    TaskChanger("Задание 4",

                         "Решить задачу, используя класс HashSet" +
                         "\r\nДан текстовый файл." +
                         "\r\nОбработать содержимое файла с использованием HashSet." +
                         "\r\nФайл содержит текст на русском языке. " +
                         "\r\nКакие цифры встречаются в тексте?",

                         "",

                         0);
                    break;

                case "Lab 5: Задание 5":
                    TaskChanger("Задание 5",

                         "Решить задачу, используя класс Dictionary" +
                         "\r\n(или класс SortedList)" +
                         "\r\nРешить текстовую задачу с использованием словаря " +
                         "\r\n(входные данные читать из текстового файла)" +
                         "\r\nИмеется список людей с указанием их фамилии, " +
                         "\r\nимени и даты рождения." +
                         "\r\nНапишите программу,которая будет определять" +
                         "\r\nсамого старшего человека из этого списка" +
                         "\r\nи выводить его фамилию и имя," +
                         "\r\nа если имеется несколько самых старших людей" +
                         "\r\nс одинаковой датой рождения," +
                         "\r\nто определять их количество." +
                         "\r\nНа вход программе в первой строке" +
                         "\r\nподается количество людей в списке N." +
                         "\r\nВ каждой изпоследующих N строк находится" +
                         "\r\nинформация в следующем формате:" +
                         "\r\n<Фамилия> <Имя> <Дата рождения>" +
                         "\r\nгде <Фамилия> – строка, состоящая не более," +
                         "\r\nчем из 20 символов без пробелов, <Имя> – строка," +
                         "\r\nсостоящая не более, чем из 20 символов без пробелов," +
                         "\r\n<Дата рождения> – строка, имеющая вид" +
                         "\r\nДД.ММ.ГГГГ, где ДД – двузначное число от 01 до 31," +
                         "\r\nММ – двузначное число от 01 до 12, ГГГГ –" +
                         "\r\nчетырехзначное число от 1800 до 2100." +
                         "\r\nПример входной строки:" +
                         "\r\nИванов Сергей 27.03.1993" +
                         "\r\nПрограмма должна вывести фамилию и имя" +
                         "\r\nсамого старшего человека в списке." +
                         "\r\nПример выходных данных:" +
                         "\r\nИванов Сергей" +
                         "\r\nЕсли таких людей, несколько," +
                         "\r\nто программа должна вывести их количество." +
                         "\r\nПример вывода в" +
                         "\r\nэтом случае:" +
                         "\r\n3",

                         "",

                         0);
                    break;

                case "Lab 5: Задание 6":
                    TaskChanger("Задание 6",

                         "XML – cериализация и коллекции" +
                         "\r\nФайл содержит сведения об игрушках:" +
                         "\r\nназвание игрушки, ее стоимость в рублях и возрастные" +
                         "\r\nграницы (например, игрушка может предназначаться для детей от двух до пяти лет)." +
                         "\r\nПолучить название самой дорогой игрушки, подходящей детям двух-трех лет.",

                         "",

                         0);
                    break;

                case "Lab 6":
                    DelElem.IsEnabled = false;
                    CorrectElem.IsEnabled = false;
                    AddElem.IsEnabled = false;
                    userValue1.IsEnabled = false;
                    ChooseMatrixA.IsEnabled = false;
                    ChooseMatrixB.IsEnabled = false;
                    ChooseMatrixC.IsEnabled = false;
                    ShowDataBase.IsEnabled = false;
                    TaskChanger("",

                         "1. Чтение базы данных из excel файла",

                         "",

                         3,
                         "ID = ");
                    break;

                default:
                    break;
            }
        }

        private void DarkLightToggle_Click(object sender, RoutedEventArgs e)
        {
            isDarkTheme = !isDarkTheme;
            VisualChanger.ChangeTheme(isDarkTheme, Theme);
        }

        private void showHideTaskText_Click(object sender, RoutedEventArgs e)
        {
            TaskBox.Visibility = VisualChanger.VisibleReverse(TaskBox.Visibility);
        }

        private void showHideEllipses_Click(object sender, RoutedEventArgs e)
        {
            Ellipses.Visibility = VisualChanger.VisibleReverse(Ellipses.Visibility);
        }

        private void ChooseConstructor1_Click(object sender, RoutedEventArgs e)
        {
            ChooseConstructor1.IsEnabled = false;
            ChooseConstructor2.IsEnabled = true;
            ChooseConstructor3.IsEnabled = true;
            userValue2.Text = "";
            userValue3.Text = "";
            ChangeInputField("n = ", "m = ", "arr = ");
        }

        private void ChooseConstructor2_Click(object sender, RoutedEventArgs e)
        {
            ChooseConstructor1.IsEnabled = true;
            ChooseConstructor2.IsEnabled = false;
            ChooseConstructor3.IsEnabled = true;

            userValue2.Text = "";
            userValue3.Text = "";
            ChangeInputField("n = ", "maxValue = ", "minValue(optional) = ");
        }

        private void ChooseConstructor3_Click(object sender, RoutedEventArgs e)
        {
            ChooseConstructor1.IsEnabled = true;
            ChooseConstructor2.IsEnabled = true;
            ChooseConstructor3.IsEnabled = false;
            userValue2.Text = "";
            userValue3.Text = "";
            ChangeInputField("n = ");
        }

        private void ChooseMatrixA_Click(object sender, RoutedEventArgs e)
        {
            ChooseMatrixA.IsEnabled = false;
            ChooseMatrixB.IsEnabled = true;
            ChooseMatrixC.IsEnabled = true;
        }

        private void ChooseMatrixB_Click(object sender, RoutedEventArgs e)
        {
            ChooseMatrixA.IsEnabled = true;
            ChooseMatrixB.IsEnabled = false;
            ChooseMatrixC.IsEnabled = true;
        }

        private void ChooseMatrixC_Click(object sender, RoutedEventArgs e)
        {
            ChooseMatrixA.IsEnabled = true;
            ChooseMatrixB.IsEnabled = true;
            ChooseMatrixC.IsEnabled = false;
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {            
            try
            {
                resultLabel.Content = resultLabel.Content + "\nA^т+B-3*C:\n" + (Matrix.Transpose(A) + B - 3 * C).ToString();
            }
            catch (Exception ex)
            {
                resultLabel.Content = resultLabel.Content + "\nA^т+B-3*C:\n" + ex.Message;
            }
        }

        private void secondShowResultButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowDataBase_Click(object sender, RoutedEventArgs e)
        {
            if (!ChooseMatrixA.IsEnabled)
            {
                resultLabel.Content = ExcelDataBase.ShowDataBase(excelDataBase.GetAccount());
            }
            else if (!ChooseMatrixB.IsEnabled)
            {
                resultLabel.Content = ExcelDataBase.ShowDataBase(excelDataBase.GetExchangeRate());
            }
            else if (!ChooseMatrixC.IsEnabled)
            {
                resultLabel.Content = ExcelDataBase.ShowDataBase(excelDataBase.GetAccrual());
            }
        }

        private void DelElem_Click(object sender, RoutedEventArgs e)
        {
            DelElem.IsEnabled = false;
            CorrectElem.IsEnabled = true;
            AddElem.IsEnabled = true;
        }

        private void CorrectElem_Click(object sender, RoutedEventArgs e)
        {
            DelElem.IsEnabled = true;
            CorrectElem.IsEnabled = false;
            AddElem.IsEnabled = true;
        }

        private void AddElem_Click(object sender, RoutedEventArgs e)
        {
            DelElem.IsEnabled = true;
            CorrectElem.IsEnabled = true;
            AddElem.IsEnabled = false;
        }

        private void Execute_Click(object sender, RoutedEventArgs e)
        {
            if (LabChecker.IsPosetiveInt(userValue1.Text))
            {
                DoWithTheChosenOne(
                    !ChooseMatrixA.IsEnabled, 
                    !ChooseMatrixB.IsEnabled, 
                    !ChooseMatrixC.IsEnabled, 
                    () => excelDataBase.DelElemInAccounts(int.Parse(userValue1.Text)), 
                    () => excelDataBase.DelElemInExchangeRates(int.Parse(userValue1.Text)), 
                    () => excelDataBase.DelElemInAccrual(int.Parse(userValue1.Text)));
            }
        }

        private void DoWithTheChosenOne(bool button1, bool button2, bool button3, Action funcA, Action funcB, Action funcC)
        {
            if (button1)
            {
                funcA();
            }
            else if (button2)
            {
                funcB();
            }
            else if (button3)
            {
                funcC();
            }
        }
    }
}
