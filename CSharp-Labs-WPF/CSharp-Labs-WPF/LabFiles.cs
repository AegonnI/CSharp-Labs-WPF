using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace CSharp_Labs_WPF
{
    internal class LabFiles
    {
        public static void WriteInBinaryFile(string filePath)
        {
            // Открытие потока для записи в файл
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                // Запись данных в поток
                BinaryWriter writer = new BinaryWriter(fileStream);
            }
        }

        public static void ReadBinaryFile(string filePath)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                BinaryReader writer = new BinaryReader(fileStream);
            }
        }

        public static void CreateBinaryFile(string filePath, int numbers_count)
        {
            Random random = new Random();
            // Открытие потока для записи в файл
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                // Запись данных в поток
                BinaryWriter writer = new BinaryWriter(fileStream);
                for (int i = 0; i < numbers_count; i++) {
                    writer.Write(random.Next(50));
                }
            }
        }
    }
}
