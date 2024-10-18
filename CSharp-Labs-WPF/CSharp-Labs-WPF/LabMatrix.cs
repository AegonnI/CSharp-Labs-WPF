using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Labs_WPF
{
    internal class LabMatrix
    {
        private int[,] matrix;

        public LabMatrix(int[,] maxtrix)
        {
            this.matrix = maxtrix;
        }

        public LabMatrix(int n, int maxValue)
        {
            matrix = new int[n, n];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rand.Next(maxValue);
                }
            }
        }

        public LabMatrix(int n)
        {
            matrix = new int[n, n];
            int x = n / 2, y = n / 2;
            int dx = 0, dy = -1;
            if (n % 2 == 0)
                y--;
            for (int i = 1; i < n*n+1; i++)
            {
                matrix[y, x] = n*n-i+1;
                if (x + dx >= n || x + dx < 0 || y + dy >= n || y + dy < 0 || matrix[y + dy,x + dx] != 0)
                {
                    int t = dx;
                    dx = -dy;
                    dy = t;
                }
                x += dx;
                y += dy;
            }      
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0;i < matrix.GetLength(0); i++)
            {
                for(int j = 0;j < matrix.GetLength(1); j++)
                {
                    result += " " + matrix[i, j]; 
                }
                result += "\n";
            }
            return result;
        }
    }
}
