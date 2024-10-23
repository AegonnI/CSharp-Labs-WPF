using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace CSharp_Labs_WPF
{
    internal static class LabFiles
    {
        struct Toy
        {
            public string name;
            public int price;
            public int minAge;
            public int maxAge;
        }

        public static void WriteWithoutPunctuation(string sourceFilePath, string newFilePath)
        {
            StreamReader sourceFile = new StreamReader(sourceFilePath);
            StreamWriter newFile = new StreamWriter(newFilePath);

            while (!sourceFile.EndOfStream)
            {
                string line = sourceFile.ReadLine();
                if (line.IndexOfAny(".,;:!?-()<>".ToCharArray()) == -1)
                {
                    newFile.WriteLine(line);
                }
            }
            sourceFile.Close();
            newFile.Close();
        }

        public static int DiffBetweenFirstAndMin(string fileName)
        {
            StreamReader file = new StreamReader(fileName);
            string[] numbs = file.ReadToEnd().Split(' ');
            int first = int.Parse(numbs[0]);
            int min = first;
            for (int i = 1; i < numbs.Length-1; i++)
            {
                min = Math.Min(min, int.Parse(numbs[i]));
            }

            //while (!file.EndOfStream)
            //{
            //    min = Math.Min(min, int.Parse(file.ReadLine()));
            //}
            //file.Close();

            return first - min;
        }

        public static int FindSumOfElemsWithGivenEnding(string fileName, int ending)
        {
            StreamReader file = new StreamReader(fileName);
            int sum = 0;
            while (!file.EndOfStream)
            {
                int num = int.Parse(file.ReadLine());
                if (num % Math.Pow(10, (num.ToString().Length-1)) == ending)
                {
                    sum += num;
                }
            }
            file.Close();
            return sum;
        }

        public static void CreateRandomFile(string fileName, int numbers_count, int maxValue, int minValue = 0)
        {
            Random random = new Random();
            StreamWriter f = new StreamWriter(fileName);
            for (int i = 0; i < numbers_count; i++)
            {
                f.WriteLine(random.Next(minValue, maxValue));
            }
            f.Close();
        }

        public static void CreateRandomOneLineFile(string fileName, int numbers_count, int maxValue, int minValue = 0)
        {
            Random random = new Random();
            StreamWriter f = new StreamWriter(fileName);
            for (int i = 0; i < numbers_count; i++)
            {
                f.Write(random.Next(minValue, maxValue) + " ");
            }
            f.Close();
        }



        public static string ReadFile(string fileName, string separator = " ")
        {
            StreamReader file = new StreamReader(fileName);
            List<string> list = new List<string>();
            while (!file.EndOfStream)
            {
                list.Add(file.ReadLine());
            }
            file.Close();
            return string.Join(separator, list.ToArray());
        }

        public static string MostExpensiveInTheRange(string sourceFilePath)
        {
            string name = "No one";
            int maxPrice = 0;
            using (FileStream soursceFile = new FileStream(sourceFilePath, FileMode.Open))
            {
                BinaryReader reader = new BinaryReader(soursceFile);                            
                Toy toy = new Toy();
                toy.name = reader.ReadString();
                toy.price = reader.ReadInt32();
                toy.minAge = reader.ReadInt32();
                toy.maxAge = reader.ReadInt32();
                if (maxPrice < toy.price)
                {
                    if (toy.minAge == 2 && toy.maxAge == 3)
                    {
                        maxPrice = toy.price;
                        name = toy.name;
                    }
                }
            }
            return name;
        }

        public static void CreateFileWithToys(string sourceFilePath, string[] toysNames)
        {
            using (FileStream soursceFile = new FileStream(sourceFilePath, FileMode.Create))
            {
                Random random = new Random();
                BinaryWriter writer = new BinaryWriter(soursceFile);
                for (int i = 0; i < toysNames.Length; i++)
                {                  
                    Toy toy = new Toy();
                    toy.name = toysNames[i];
                    toy.price = random.Next(0, 100);
                    int minAge;
                    toy.minAge = (minAge = random.Next(3));
                    toy.maxAge = random.Next(minAge, 15);

                    writer.Write(toy.name);
                    writer.Write(toy.price);
                    writer.Write(toy.minAge);
                    writer.Write(toy.maxAge);
                }
            }
        }

        public static void RemoveDuplicates(string sourceFilePath, string newFilePath)
        {
            using (FileStream soursceFile = new FileStream(sourceFilePath, FileMode.Open))
            {
                BinaryReader reader = new BinaryReader(soursceFile);
                using (FileStream newFile = new FileStream(newFilePath, FileMode.Create))
                {
                    BinaryWriter writer = new BinaryWriter(newFile);
                    HashSet<int> unicNumbs = new HashSet<int>();
                    while (reader.BaseStream.Position < reader.BaseStream.Length) 
                    { 
                        int v = reader.ReadInt32();
                        if (!unicNumbs.Contains(v))
                        {
                            unicNumbs.Add(v);
                            writer.Write(v);
                        }                        
                    }
                }
            }
        }

        public static string BinaryFileToString(string filePath, string separator, string splitter, params Type[] types)
        {
            List<string> list = new List<string>();
            string result = "";
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                BinaryReader reader = new BinaryReader(fileStream);
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    if (types.Length == 0)
                    {
                        //list.Add(reader.ReadInt32().ToString());
                        result += reader.ReadInt32().ToString() + splitter;
                    }
                    else
                    {
                        for (int i = 0; i < types.Length; i++)
                        {                            
                            if (types[i] == typeof(int))
                            {
                                //list.Add(reader.ReadInt32().ToString());
                                result += reader.ReadInt32().ToString() + splitter;
                            }
                            else if (types[i] == typeof(string))
                            {
                                //list.Add(reader.ReadString().ToString());
                                result += reader.ReadString().ToString() + splitter;
                            }
                        }
                        result = result.Substring(0, result.Length-1) + separator;
                    }
                    
                }
            }
            return result.Substring(0, result.Length - 1);
            //return string.Join(" ", list.ToArray());
        }

        public static void CreateBinaryFile(string filePath, int numbers_count, int maxValue, int minValue = 0)
        {
            Random random = new Random();
            // Открытие потока для записи в файл
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                // Запись данных в поток
                BinaryWriter writer = new BinaryWriter(fileStream);
                for (int i = 0; i < numbers_count; i++) 
                {
                    writer.Write(random.Next(minValue, maxValue));
                }
            }
        }
    }
}
