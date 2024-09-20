using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Labs_WPF
{
    public static class LabMath
    {
        public static string ResultText(Func<bool> checkFunc, Func<string> resultFunc)
        {
            if (checkFunc())
            {
                return "Результат: " + resultFunc();
            }
            else
            {                
                return "Incorrect input, try again!";
            }
        }

        // Lab1 Ex1-1

        public static double fraction(double x)
        {
            return (double)((decimal)(x) - Math.Truncate((decimal)(x)));
        }

        // Lab1 Ex1-3

        public static int charToNum(char x)
        {
            return x - 48;
        }

        // Lab1 Ex1-5

        public static bool is2Digits(int x)
        {
            return Math.Abs(x).ToString().Length == 2;
        }

        // Lab1 Ex1-7

        public static bool isInRange(int a, int b, int num)
        {
            return Math.Min(a, b) <= num && num <= Math.Max(a, b);
        }

        // Lab1 Ex1-9

        public static bool isEqual(int a, int b, int c)
        {
            return (a == b) && (b == c);
        }

        // Lab1 Ex2-1

        public static int abs(int x)
        {
            if (x >= 0)
            {
                return x;
            }
            return -x;
        }

        // Lab1 Ex2-3

        public static bool is35(int x)
        {
            return (x % 5 == 0) != (x % 3 == 0);
        }

        // Lab1 Ex2-5

        public static int max3(int x, int y, int z)
        {
            return Math.Max(Math.Max(x, y), z);
        }

        // Lab1 Ex2-7

        public static int sum2(int x, int y)
        {
            if (10 <= x + y && x + y <= 19)
            {
                return 20;
            }
            return x + y;
        }

        // Lab1 Ex2-9

        public static String day(int x)
        {
            switch (x)
            {
                case 1:
                    return "понедельник";
                case 2:
                    return "вторник";
                case 3:
                    return "среда";
                case 4:
                    return "четверг";
                case 5:
                    return "пятница";
                case 6:
                    return "суббота";
                case 7:
                    return "воскресенье";
                default:
                    return "это не день недели";
            }
        }

        // Lab1 Ex3-1

        public static String listNums(int x)
        {
            string result = String.Empty;

            for (int i = 0; i <= x; i++)
            {
                result += i.ToString() + ' ';
            }

            return result.Substring(0, result.Length - 1);
        }

        // Lab1 Ex3-3

        public static String chet(int x)
        {
            string result = String.Empty;

            for (int i = 0; i <= x; i += 2)
            {
                result += i.ToString() + ' ';
            }

            return result.Substring(0, result.Length - 1);
        }

        // Lab1 Ex3-5

        public static int numLen(long x)
        {
            return x.ToString().Length;
        }

        // Lab1 Ex3-7

        public static string square(int x)
        {
            string square = String.Empty;
            for (int i = 0; i < x; i++)
            {
                square += "*";
            }
            for (int i = 0; i < x - 1; i++)
            {
                square += "\n" + square.Substring(0, x);
            }
            return "\n" + square;
        }

        // Lab1 Ex3-9

        public static string rightTriangle(int x)
        {
            string square = String.Empty;
            if (x != 0)
            {
                for (int i = 0; i < x - 1; i++)
                {
                    square += " ";
                }
                square += "*";
                for (int i = 1; i < x; i++)
                {
                    square += "\n" + square.Substring(0, x - i - 1) + "*" + square.Substring(square.Length - i, i);
                }
            }
            return "\n" + square;
        }

        // Lab1 Ex4-1

        public static int findFirst(int[] arr, int x)
        {
            return Array.IndexOf(arr, x);
        }

        // Lab1 Ex4-3

        public static int maxAbs(int[] arr)
        {
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (Math.Abs(arr[i]) > Math.Abs(max))
                {
                    max = arr[i];
                }
            }
            return max;
        }

        // Lab1 Ex4-5

        public static int[] add(int[] arr, int[] ins, int pos)
        {
            int[] result = new int[arr.Length + ins.Length];
            int j = 0;
            int k = 0;
            for (int i = 0; i < arr.Length + ins.Length; i++)
            {
                if (pos <= i && i <= pos + ins.Length - 1)
                {
                    result[i] = ins[k];
                    k++;
                }
                else
                {
                    result[i] = arr[j];
                    j++;
                }
            }
            return result;
        }

        // Lab1 Ex4-7

        public static int[] reverseBack(int[] arr)
        {
            Array.Reverse(arr);
            return arr;
        }

        // Lab1 Ex4-9

        public static int[] findAll(int[] arr, int x)
        {
            List<int> indexes = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == x)
                {
                    indexes.Add(i);
                }
            }
            if (indexes.Count != 0)
            {
                return indexes.ToArray();
            }
            indexes.Add(-1);
            return indexes.ToArray();
        }
    }
}
