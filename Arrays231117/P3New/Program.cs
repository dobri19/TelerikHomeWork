using System;
using System.Linq;

namespace P3New
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string dimensions = Console.ReadLine();
            int[] arrDim = dimensions.Split(' ').Select(int.Parse).ToArray();
            int n = arrDim[0];
            int m = arrDim[1];
            string[][] matrix = new string[n][];

            for (int i = 0; i < n; i++)
            {
                matrix[i] = new string[m];
            }
            string text;

            for (int i = 0; i < n; i++)
            {
                text = Console.ReadLine();
                matrix[i] = text
                .Split(' ')
                .Select(z => z)
                .ToArray();
            }

            int max = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int curent = CheckRow(matrix, i, j, 1);
                    if (curent > max)
                    {
                        max = curent;
                    }
                    curent = CheckCol(matrix, i, j, 1);
                    if (curent > max)
                    {
                        max = curent;
                    }
                    curent = CheckDiagonal(matrix, i, j, 1);
                    if (curent > max)
                    {
                        max = curent;
                    }
                }
            }
            Console.WriteLine(max);
        }
        static int CheckRow(string[][] matrix, int row, int col, int curent)
        {
            if ((col < matrix[row].Length - 1) && (matrix[row][col + 1] == matrix[row][col]))
            {
                curent++;
                curent = CheckRow(matrix, row, col + 1, curent);
            }
            return curent;
        }

        static int CheckCol(string[][] matrix, int row, int col, int curent)
        {
            if ((row < matrix.Length - 1) && (matrix[row + 1][col] == matrix[row][col]))
            {
                curent++;
                curent = CheckCol(matrix, row + 1, col, curent);
            }
            return curent;
        }

        static int CheckDiagonal(string[][] matrix, int row, int col, int curent)
        {
            if ((col < matrix[row].Length - 1) && (row < matrix.Length - 1) && (matrix[row + 1][col + 1] == matrix[row][col]))
            {
                curent++;
                curent = CheckDiagonal(matrix, row + 1, col + 1, curent);
            }
            return curent;
        }
    }
}
