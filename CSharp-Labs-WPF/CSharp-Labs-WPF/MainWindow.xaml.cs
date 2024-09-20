using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CSharp_Labs_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string task;
        //System.Windows.Controls.Label taskTextLabel;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Tasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //task = tasksComboBox.Text;
            task = tasksComboBox.SelectedItem.ToString().Substring(38);
            resultLabel.Content = "";
            //resultLabel.Content = tasksComboBox.SelectedItem.ToString().Substring(38);
            userValue1.Text = "";
            userValue2.Text = "";
            userValue3.Text = "";

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

                default:
                    break;
            }
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
            //ChangeLabel(label4);
        }

        void ChangeInputField(string v1 = "", string v2 = "", string v3 = "")
        {
            valueName1.Content = v1;
            valueName2.Content = v2;
            valueName3.Content = v3;

            //userValue1.IsEnabled = v1 != "";
            //userValue2.IsEnabled = v2 != "";
            //userValue3.IsEnabled = v3 != "";

            if (v1 != "")
            {
                userValue1.Visibility = Visibility.Visible;
            }
            else
            {
                userValue1.Visibility = Visibility.Hidden;
            }

            if (v2 != "")
            {
                userValue2.Visibility = Visibility.Visible;
            }
            else
            {
                userValue2.Visibility = Visibility.Hidden;
            }

            if (v3 != "")
            {
                userValue3.Visibility = Visibility.Visible;
            }
            else
            {
                userValue3.Visibility = Visibility.Hidden;
            }

            //if (v3 != "")
            //{
            //    label4.Location = new Point(textBox3.Location.X, textBox3.Location.Y + 30);
            //}
            //else if (v2 != "")
            //{
            //    label4.Location = new Point(textBox2.Location.X, textBox2.Location.Y + 30);
            //}
            //else if (v1 != "")
            //{
            //    label4.Location = new Point(textBox1.Location.X, textBox1.Location.Y + 30);
            //}
        }

        //void ChangeLabel(Label label, string font = "Segoe UI", float emSize = 9F)
        //{
        //label.Font = new Font(font, emSize, FontStyle.Regular, GraphicsUnit.Point, 204);
        //}

        void ResultText(Func<bool> checkFunc, Func<string> resultFunc)
        {
            resultLabel.Content = LabMath.ResultText(
                () => checkFunc(),
                () => resultFunc());
        }
    }
}
