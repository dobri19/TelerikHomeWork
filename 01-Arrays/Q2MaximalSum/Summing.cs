using System;
using System.Linq;

namespace Q2MaximalSum
{
    public class Summing
    {
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

            int MaxSum = int.MinValue;

            for (int i = 0; i < matrix.GetLength(0) - 3; i++)
            {
                int currentSum = 0;
                for (int j = 0; j < matrix.GetLength(1) - 3; j++)
                {
                    currentSum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] +
                                 matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2] +
                                 matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];
                    if (MaxSum < currentSum)
                    {
                        MaxSum = currentSum;
                    }
                }
            }
            Console.WriteLine(MaxSum);
        }
    }
}
