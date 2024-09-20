﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Labs_WPF
{
    public static class LabChecker
    {
        public static bool IsDoubleNumber(string number)
        {
            return double.TryParse(number, out var result) && !(number[0] == '0' && number.Length != 1);
        }

        public static bool IsDecimalNumber(string number)
        {
            return decimal.TryParse(number, out var result) && !(number[0] == '0' && number.Length != 1);
        }

        public static bool IsCharADigit(string digit)
        {
            return char.TryParse(digit.ToString(), out var result)
                && 48 <= char.Parse(digit) && char.Parse(digit) <= 57;
        }

        public static bool IsIntNumber(string number)
        {
            return int.TryParse(number, out var result) && !(number[0] == '0' && number.Length != 1);
        }

        public static bool IsPosetiveOfZeroInt(string number)
        {
            if (IsIntNumber(number))
            {
                return int.Parse(number) >= 0;
            }
            return false;
        }

        public static bool IsLongNumber(string number)
        {
            return long.TryParse(number, out var result) && !(number[0] == '0' && number.Length != 1);
        }

        public static bool IsIntArray(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (!IsIntNumber(arr[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IndexNotOutside(string[] arr, string pos)
        {
            return IsIntArray(arr) && IsIntNumber(pos)
                && int.Parse(pos) <= arr.Length && int.Parse(pos) >= 0;
        }
    }
}
