using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Labs_WPF
{
    public static class LabConverter
    {
        public static int[] StringToIntArr(string[] stringArr)
        {
            int[] intArr = new int[stringArr.Length];
            for (int i = 0; i < stringArr.Length; i++)
            {
                intArr[i] = int.Parse(stringArr[i]);
            }
            return intArr;
        }

        public static string IntArrToText(int[] arr)
        {
            string result = String.Empty;

            for (int i = 0; i < arr.Length; i++)
            {
                result += arr[i].ToString() + ' ';
            }

            return result.Substring(0, result.Length - 1);
        }
    }
}
