using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Xml.Serialization;
namespace CSharp_Labs_WPF
{
    internal static class Lab5
    {
        [Serializable]
        internal class Person
        {
            public string House;
            public string Name;
            public string BirthDay;

            internal Person()
            {
                House = "А";
                Name = "А";
                BirthDay = "01.01.1800";
            }

            internal Person(string house, string name, string birthDay)
            {
                if (house == null || house.Length > 20 || house.IndexOf(" ") != -1) throw new ArgumentNullException("Invalid last name format");
                if (name == null || name.Length > 20 || name.IndexOf(" ") != -1) throw new ArgumentNullException("invalid name format");
                //if (birthDay == null || birthDay.Length != 10 ||
                //    birthDay[2] != '.' || birthDay[5] != '.' ||
                //    !int.TryParse(birthDay.Substring(0, 2), out int value1) ||
                //    !int.TryParse(birthDay.Substring(3, 2), out int value2) ||
                //    !int.TryParse(birthDay.Substring(6, 4), out int value3) ||
                //    1 < value1 || value1 > 31 ||
                //    1 < value2 || value2 > 12 ||
                //    1800 < value3 || value3 > 2100) 
                //{
                //    throw new ArgumentNullException("invalid date format");
                //}

                if (!DateTime.TryParseExact(birthDay, "dd.MM.yyyy", null, DateTimeStyles.None, out DateTime date) ||
                    1 < date.Day || date.Day > 31 ||
                    1 < date.Month || date.Month > 12 ||
                    1800 < date.Year || date.Year > 2100)
                    throw new ArgumentNullException("invalid date format");

                House = house;
                Name = name;
                BirthDay = birthDay;
            }
        }

        [Serializable]
        public struct Toy
        {
            public string name;
            public int price;
            public int minAge;
            public int maxAge;
        }

        public static void CreateToysFile(params string[] toysNames)
        {
            List<Toy> toys = new List<Toy>();
            Random random = new Random();
            for (int i = 0; i < toysNames.Length; i++)
            {
                toys.Add(new Toy { name = toysNames[i], price = random.Next(10, 100), minAge = random.Next(0, 2), maxAge = random.Next(2, 7) });
            }

            XmlSerializer xml = new XmlSerializer(typeof(List<Toy>));
            FileStream f = new FileStream("lab5-6.xml",
                                          FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
            xml.Serialize(f, toys);
        }

        //public static string MostAgePerson()
        //{

        //}

        public static HashSet<char> DigintsInText(string path)
        {
            if (!File.Exists(path)) throw new Exception("Files not found");

            HashSet<char> digits = new HashSet<char>();
            string text = File.ReadAllText(path);
            foreach (char item in text) 
            {
                if (char.IsDigit(item))
                    digits.Add(item);           
            }
            return digits;
        }

        public static List<T> SymmetricalDifference<T>(List<T> L1, List<T> L2)
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
