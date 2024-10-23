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

        public Matrix() // Конструктор по умолчанию
        {
            matrix = new int[0,0];
        }

        public Matrix(Matrix M) // Конструтор копирования
        {
            matrix = M.matrix;
        }

        public Matrix(int[,] M) // Конструтор для присваивания двумерного массива сразу
        {
            matrix = M;
        }

        public Matrix(int n, int m, int[] arr) // конструтор для ручного ввода
        {
            if (arr == null) throw new ArgumentNullException();
            if (n <= 0 || m <= 0) throw new Exception("Uncorrect Dimensions");
            if (arr.Length != n*m) throw new Exception("Array Length must be n*m");

            matrix = new int[n, m];

            int i = n - 1, j = 0;
            int si = i, sj = j;
            for (int k = 0; k < arr.Length; k++)
            {
                matrix[i, j] = arr[k];
                if (i + 1 >= n || j + 1 >= m)
                {
                    if (si > 0) si--;
                    else sj++;
                    i = si; j = sj;
                }
                else 
                {
                    i++; j++;
                }                
            }
        }

        public Matrix(int[] arr, int m) // Конструтор если известно лишь количество столбцов
        {
            if (arr == null) throw new ArgumentNullException();
            if (m <= 0) throw new Exception();

            matrix = new int[arr.Length/m, m];
            for (int i = 0, k = 0; i < arr.Length / m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = arr[k++];
                }
            }
        }

        public Matrix(int n, int maxValue, int minValue = 0) // Конструтор для генерации рандомной матрицы
        {
            if (minValue > maxValue) throw new ArgumentException();
            if (maxValue - minValue + 1 < n) throw new ArgumentException();

            matrix = new int[n, n];
            Random rand = new Random();

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

        public Matrix(int n) // Конструтор для спиральной матрицы
        {
            matrix = new int[n, n];

            int x = 0, y = 0;
            int dx = 0, dy = 1;
            for (int i = 1; i < n * n + 1; i++)
            {
                matrix[y, x] = i;
                if (x + dx >= n || x + dx < 0 || y + dy >= n || y + dy < 0 || matrix[y + dy, x + dx] != 0)
                {
                    (dx, dy) = (dy, -dx);
                }
                x += dx; y += dy;
            }
        }

        public static string WhichDeputiesHaveMore(Matrix VotesOfDeputaties)
        {
            if (VotesOfDeputaties == null) throw new ArgumentNullException();
            if (VotesOfDeputaties.matrix.GetLength(1) != 2) throw new AccessViolationException("Count of Rows != 2");

            int countMonoVotes = 0;
            for (int i = 0; i < VotesOfDeputaties.matrix.GetLength(0); i++)
            {
                if (VotesOfDeputaties.matrix[i, 0] == VotesOfDeputaties.matrix[i, 1])               
                    countMonoVotes++;
            }
            return countMonoVotes > VotesOfDeputaties.matrix.GetLength(0) - countMonoVotes ? 
                "Тех, кто не изменил решение больше" :
                "Тех, кто изменил решение больше";
        }

        public static Matrix Transpose(Matrix M)
        {
            int[,] Tmatrix = new int[M.matrix.GetLength(1), M.matrix.GetLength(0)];

            for (int i = 0; i < M.matrix.GetLength(1); i++)
            {
                for (int j = 0; j < M.matrix.GetLength(0); j++)
                {
                    Tmatrix[i, j] = M.matrix[j, i];
                }
            }
            return new Matrix(Tmatrix);
        }

        public static Matrix operator +(Matrix A, Matrix B)
        {
            if (A.matrix.GetLength(0) != B.matrix.GetLength(0) || A.matrix.GetLength(1) != B.matrix.GetLength(1))
                throw new ArgumentException("Dimensions of matrices do not match");

            Matrix M = new Matrix(A);
            for (int i = 0; i < M.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < M.matrix.GetLength(1); j++)
                {
                    M.matrix[i, j] += B.matrix[i, j];
                }
            }
            return M;
        }

        public static Matrix operator -(Matrix A, Matrix B)
        {
            if (A.matrix.GetLength(0) != B.matrix.GetLength(0) || A.matrix.GetLength(1) != B.matrix.GetLength(1))
                throw new ArgumentException("Dimensions of matrices do not match");

            Matrix M = new Matrix(A);
            for (int i = 0; i < M.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < M.matrix.GetLength(1); j++)
                {
                    M.matrix[i, j] -= B.matrix[i, j];
                }
            }
            return M;
        }

        public static Matrix operator *(int a, Matrix A)
        {
            Matrix M = new Matrix(A);
            for (int i = 0; i < A.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < A.matrix.GetLength(1); j++)
                {
                    M.matrix[i, j] *= a;
                }
            }
            return M;
        }

        // Метод чтобы выводить любое количество матриц
        public static string MatrixOutput(string[] names, params Matrix[] M)
        {
            string result = "";
            for (int i = 0; i < M.Length; i++)
            {
                result += names[i] + ":" + '\n';
                if (M[i].ToString() != "")
                    result += M[i].ToString();
                else
                    result += "Matrix is empty";           
                result += "\n\n";
            }
            return result;
        }

        public override string ToString()
        {
            int[] maxLen = new int[matrix.GetLength(1)];
            for (int j = 0; j < matrix.GetLength(1); j++)
                for (int i = 0; i < matrix.GetLength(0); i++)
                    maxLen[j] = Math.Max(matrix[i, j].ToString().Length, maxLen[j]);

            string result = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    for (int k = 0; k < maxLen[j] - matrix[i, j].ToString().Length; k++)
                        result += " ";

                    result += matrix[i, j].ToString() + " ";
                }
                if (i != matrix.GetLength(0) - 1)
                    result += "\n";
            }
            return result;
        }

        public int[,] GetMatrix
        {   
            get { return matrix; }
        }
    }
}
