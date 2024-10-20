using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace CSharp_Labs_WPF
{
    internal class Matrix
    {
        private int[,] matrix;

        public Matrix(int[,] maxtrix)
        {
            this.matrix = maxtrix;
        }

        public Matrix(uint n, uint m, int[] arr)
        {
            matrix = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {

                }
            }
        }

        public Matrix(int n, int minValue, int maxValue)
        {
            matrix = new int[n, n];
            Random rand = new Random();

            if (minValue > maxValue)
            {
                throw new ArgumentException();
            }

            if (maxValue - minValue + 1 < n)
            {
                throw new ArgumentException();
            }

            for (int i = 0; i < n; i++)
            {
                matrix[i, 0] = rand.Next(minValue + n - 1, maxValue);
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    matrix[i, j] = rand.Next(minValue + n - j - 1, matrix[i, j - 1]);
                }
            }
        }

        public Matrix(int n, int maxValue)
        {
            matrix = new int[n, n];
            Random rand = new Random();

            for (int i = 0; i < n; i++)
            {
                matrix[i, 0] = rand.Next(n - 1, maxValue);
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    matrix[i, j] = rand.Next(n - j - 1, matrix[i, j - 1]);
                }
            }
        }

        public Matrix(uint n)
        {
            matrix = new int[n, n];

            int x = 0, y = 0;
            int dx = 0, dy = 1;
            for (int i = 1; i < n * n + 1; i++)
            {
                matrix[y, x] = i;
                if (x + dx >= n || x + dx < 0 || y + dy >= n || y + dy < 0 || matrix[y + dy, x + dx] != 0)
                {
                    int t = dx;
                    dx = dy;
                    dy = -t;
                }
                x += dx;
                y += dy;
            }
        }

        public void Transpose()
        {
            int[,] Tmatrix = new int[matrix.GetLength(1), matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    Tmatrix[i, j] = matrix[j, i];
                }
            }
            matrix = Tmatrix;
        }

        public static Matrix operator +(Matrix A, Matrix B)
        {
            if (A.matrix.GetLength(0) != B.matrix.GetLength(0) || A.matrix.GetLength(1) != B.matrix.GetLength(1))
            {
                throw new ArgumentException("Dimensions of matrices do not match");
            }

            for (int i = 0; i < A.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < A.matrix.GetLength(1); j++)
                {
                    A.matrix[i, j] += B.matrix[i, j];
                }
            }
            return A;
        }

        public static Matrix operator -(Matrix A, Matrix B)
        {
            if (A.matrix.GetLength(0) != B.matrix.GetLength(0) || A.matrix.GetLength(1) != B.matrix.GetLength(1))
            {
                throw new ArgumentException("Dimensions of matrices do not match");
            }

            for (int i = 0; i < A.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < A.matrix.GetLength(1); j++)
                {
                    A.matrix[i, j] -= B.matrix[i, j];
                }
            }
            return A;
        }

        public static Matrix operator *(int a, Matrix A)
        {
            for (int i = 0; i < A.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < A.matrix.GetLength(1); j++)
                {
                    A.matrix[i, j] *= a;
                }
            }
            return A;
        }

        // 1 2 3 - 1 4 7 3
        // 4 5 6 - 2 5 8 2
        // 7 8 9 - 3 6 9 1
        // 3 2 1

        public override string ToString()
        {
            //int[] maxLen = new int[matrix.GetLength(1)];
            //for (int j = 0; j < matrix.GetLength(1); j++)
            //{
            //    for (int i = 0; i < matrix.GetLength(0); i++)
            //    {
            //        maxLen[j] = Math.Max(matrix[i, j].ToString().Length, maxLen[j]);
            //    }
            //}

            //string result = "";
            //for (int i = 0; i < matrix.GetLength(0); i++)
            //{
            //    for (int j = 0; j < matrix.GetLength(1); j++)
            //    {
            //        for (int k = 0; k < maxLen[j]-matrix[i, j].ToString().Length; k++)
            //        {
            //            result += " ";
            //        }
            //        result += matrix[i, j].ToString() + " ";
            //    }
            //    result += "\n";
            //}
            //return result;

            int maxLength = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    maxLength = Math.Max(maxLength, matrix[i, j].ToString().Length);
                }
            }

            string[] matrixLines = new string[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string line = "";
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    line += matrix[i, j].ToString().PadLeft(maxLength + 1) + " ";
                }
                matrixLines[i] = line;
            }
            return string.Join(Environment.NewLine, matrixLines);
        }
    }
}
