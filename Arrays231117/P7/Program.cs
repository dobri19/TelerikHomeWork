using System;
using System.Linq;

namespace P7
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string dimensions = Console.ReadLine();
            int[] arrDim = dimensions.Split(' ').Select(int.Parse).ToArray();
            int n = arrDim[0];
            int m = arrDim[1];
            int[,] matrix = new int[n, m];
            int count = 0;
            int count2 = 3;

            for (int j = 0; j < m; j++)
            {
                for (int i = n - 1; i >= 0; i--)
                {
                    matrix[i, j] = count;
                    count += 3;
                }
                count2 += 3;
                count = count2;
            }

            int direct = int.Parse(Console.ReadLine());

            string[,] matrixDir = new string[direct, 2];
            for (int i = 0; i < direct; i++)
            {
                string[] columns = Console.ReadLine().Split(' ').ToArray();
                matrixDir[i, 0] = columns[0];
                matrixDir[i, 1] = columns[1];
            }

            PrintMatrix(matrix);
            PrintMatrix(matrixDir);
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j != matrix.GetLength(1))
                    {
                        Console.Write(matrix[i, j]+" ");
                    }
                    else
                    {
                        Console.Write(matrix[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j != matrix.GetLength(1))
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                    else
                    {
                        Console.Write(matrix[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
