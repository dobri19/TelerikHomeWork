using System;
using System.Linq;

namespace P6Area
{
    public class Program
    {
        static int bestLength = 0, bestNumber = 0;
        static int currentLength = 0, currentNumber = 0;

        public static void Main(string[] args)
        {
            string dimensions = Console.ReadLine();
            int[] arrDim = dimensions.Split(' ').Select(int.Parse).ToArray();
            int n = arrDim[0];
            int m = arrDim[1];
            int[,] matrix = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                int[] columns = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = columns[j];
                }
            }

            FindBestAreaLength(matrix);
        }

        static void FindBestAreaLength(int[,] matrix)
        {
            bestLength = bestNumber = 0;

            for (int row = 0; row < matrix.GetLongLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLongLength(1); col++)
                {
                    currentNumber = matrix[row, col];
                    currentLength = 0;

                    GetAreaLength(row, col, matrix);

                    if (currentLength > bestLength)
                    {
                        bestLength = currentLength;
                        bestNumber = currentNumber;
                    }
                }
            }

            Console.WriteLine(bestLength);
        }

        static void GetAreaLength(int row, int col, int[,] matrix)
        {
            if (row < 0 || row >= matrix.GetLongLength(0) ||
                col < 0 || col >= matrix.GetLongLength(1) || matrix[row, col] == 0)
                return;

            if (matrix[row, col] == currentNumber)
            {
                matrix[row, col] = 0;
                currentLength++;

                GetAreaLength(row - 1, col, matrix);
                GetAreaLength(row + 1, col, matrix);
                GetAreaLength(row, col - 1, matrix);
                GetAreaLength(row, col + 1, matrix);
            }
        }
    }
}
