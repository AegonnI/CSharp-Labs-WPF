using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Labs_WPF
{
    internal static class Lab5<T>
    {
        public static List<T> SymmetricalDifference(List<T> L1, List<T> L2)
        {
            return L1.Except(L2).Union(L2.Except(L1)).ToList();
        }

        public static LinkedList<T> DeleteAllBetweenMinMax<T>(LinkedList<T> L) where T : IComparable
        {
            bool flag = true;
            LinkedList<T> list = new LinkedList<T>();
            foreach (T item in L)
            {
                if (item.CompareTo(L.Min()) == 0)
                {
                    list.AddLast(item);
                    flag = false;
                }
                else if (item.CompareTo(L.Max()) == 0)
                {
                    list.AddLast(item);
                    flag = true;
                }
                else if (flag)
                {
                    list.AddLast(item);
                }
            }
            return list;
        }

        public static int GetIndexOfMinElement<T>(LinkedList<T> list) where T : IComparable
        {
            int minIndex = 0;
            T minValue = list.First.Value;

            int index = 0;
            foreach (T item in list)
            {
                if (item.CompareTo(minValue) < 0)
                {
                    minValue = item;
                    minIndex = index;
                }
                index++;
            }

            return minIndex;
        }
    }
}
