using System;
using System.Linq;

namespace P2MaxSum
{
    public class MaximalSum
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
            int x = 0;
            int y = 0;

            while (x <= n - 3 && y <= m - 3)
            {
                int currentSum = 0;
                for (int i = x; i < x + 3; i++)
                {
                    for (int j = y; j < y + 3; j++)
                    {
                        currentSum += matrix[i, j];
                    }
                }

                if ((y + 4) <= m)
                {
                    y++;
                }
                else if ((y + 4) > m)
                {
                    y = 0;
                    x++;
                }

                //x++;
                //y++;

                if (MaxSum < currentSum)
                {
                    MaxSum = currentSum;
                }
            }

            Console.WriteLine(MaxSum);

            //for (int i = 0; i < n; i++)
            //{
            //    for (int j = 0; j < n; j++)
            //    {
            //        if (j != n - 1)
            //        {
            //            Console.Write(matrix[i, j] + " ");
            //        }
            //        else
            //        {
            //            Console.Write(matrix[i, j]);
            //        }
            //    }
            //    Console.WriteLine();
            //}
        }
    }
}
