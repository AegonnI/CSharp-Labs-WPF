using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Shapes;
using System.Xml.Serialization;
using static CSharp_Labs_WPF.Lab5;
namespace CSharp_Labs_WPF
{
    public static class Lab5
    {
        [Serializable]
        public struct Toy
        {
            public string name;
            public int price;
            public int minAge;
            public int maxAge;
        }

        // Ex1
        public static List<T> SymmetricalDifference<T>(List<T> L1, List<T> L2)
        {
            return L1.Except(L2).Union(L2.Except(L1)).ToList();
        }

        // Ex2
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

        // Ex3
        public static HashSet<HashSet<string>> CreateShowStat(string path, int showCount)
        {
            if (!File.Exists(path)) throw new Exception("Files not found");
            string[] shows = File.ReadAllText(path).Split('\n');

            HashSet<HashSet<string>> stat = new HashSet<HashSet<string>>();
            Random random = new Random();
            for (int i = 0; i < showCount; i++)
            {
                int r = random.Next(showCount+1);
                HashSet<string> hashSet = new HashSet<string>();
                for (int j = 0; j < r; j++)
                {
                    hashSet.Add(shows[random.Next(shows.Length)]);
                }
                stat.Add(hashSet);
            }
            return stat;
        }

        public static string DouHashSetToString(HashSet<HashSet<string>> dHashSet)
        {
            string res = "";
            int i = 1;
            foreach (HashSet<string> hashSet in dHashSet)
            {
                res += i.ToString() + ": ";
                foreach (string item in hashSet)
                {
                    res += item.Trim('\r', '\n') + ", ";
                }
                i++;
                res = res.Trim(',', ' ') + "\n";
            }
            return res.Trim('\n');
        }

        public static string ShowRating(string path, HashSet<HashSet<string>> statistics)
        {
            if (!File.Exists(path)) throw new Exception("Files not found");

            string[] showsNames = File.ReadAllText(path).Split('\n');

            Dictionary<string, int> fansCount = new Dictionary<string, int>();
            foreach (string show in showsNames)
            {
                fansCount[show] = 0;
            }
            
            foreach (HashSet<string> shows in statistics)
            {
                foreach (string show in shows)
                {
                    fansCount[show] += 1;
                }
            }

            string res = "";
            int maxLength = fansCount.Keys.Max(s => s.Trim('\r', '\n').Length);

            foreach (KeyValuePair<string, int> pair in fansCount)
            {
                res += (pair.Key.Trim('\r', '\n') + ": ").PadRight(maxLength+2) + (pair.Value == statistics.Count ? "all" : (pair.Value == 0 ? "no one" : "some")) + "\n";
            }

            return res.Trim('\n');

        }

        // Ex4
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


        // Ex5
        public static string GetOldestHuman(string path)
        {
            if (!File.Exists(path)) throw new Exception("File not Found");
                      
            int oldestCount = 1;
            DateTime date = new DateTime(2100, 12, 31);
            Dictionary<DateTime, string> person = new Dictionary<DateTime, string>();

            StreamReader reader = new StreamReader(path);
            while (!reader.EndOfStream)
            {
                string[] line = reader.ReadLine().Split(' ');
                if (DateTime.TryParseExact(line[2], "dd.MM.yyyy", null, DateTimeStyles.None, out DateTime personDate) && 
                    line[0].Length <= 20 && line[1].Length <= 20 && date.Year <= 2100 && date.Year >= 1800)
                {
                    person[personDate] = line[0] + " " + line[1];
                    if (personDate == date)
                    {
                        oldestCount++;
                    }
                    if (personDate < date)
                    {
                        oldestCount = 1;
                        date = personDate;
                    }
                }
            }
            reader.Close();

            return oldestCount == 1 ? person[date] : oldestCount.ToString();
        }

        // Ex6
        public static void CreateToysFile(string path, params string[] toysNames)
        {
            List<Toy> toys = new List<Toy>();
            Random random = new Random();
            for (int i = 0; i < toysNames.Length; i++)
            {
                toys.Add(new Toy { name = toysNames[i], price = random.Next(10, 100), minAge = random.Next(0, 3), maxAge = random.Next(3, 5) });
            }

            XmlSerializer xml = new XmlSerializer(toys.GetType());
            FileStream f = new FileStream(path,
                                          FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
            xml.Serialize(f, toys);
            f.Close();
        }

        public static string RichestToyForKids(string path)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Toy>));
            FileStream f = new FileStream(path, FileMode.Open);
            List<Toy> toys = (List<Toy>)xml.Deserialize(f);
            f.Close();
            //toys.Max(x => x.price);
            string name = "Toy not found, please grow up";
            int maxPrice = 0;
            foreach (Toy toy in toys) 
            {
                if (toy.minAge == 2 && toy.maxAge == 3 && toy.price >= maxPrice)
                {
                    name = "Richest Toy for Kinds 2-3 years old: " + toy.name;
                }
            }
            return name;
        }

        // Others
        public static T FileToValue<T>(string path)
        {
            XmlSerializer xml = new XmlSerializer(typeof(T));
            FileStream f = new FileStream(path, FileMode.Open);
            T item = (T)xml.Deserialize(f);
            f.Close();
            return item;
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
