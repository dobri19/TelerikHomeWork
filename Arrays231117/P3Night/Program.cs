using System;
using System.Linq;

namespace P3Night
{
    public class Program
    {
        static int[,] directions = { { 0, 1 }, { 1, 1 }, { -1, 1 }, { 1, 0 } };

        public static void Main(string[] args)
        {
            int bestLength = 0;
            string bestElement = string.Empty;

            string dimensions = Console.ReadLine();
            int[] arrDim = dimensions.Split(' ').Select(int.Parse).ToArray();
            int n = arrDim[0];
            int m = arrDim[1];
            string[,] matrix = new string[n, m];

            for (int i = 0; i < n; i++)
            {
                string[] columns = Console.ReadLine().Split(' ').ToArray();
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = columns[j];
                }
            }

            FindLongestSequence(matrix, ref bestElement, ref bestLength);
            Console.WriteLine(bestLength);
        }

        static void FindLongestSequence(string[,] matrix, ref string bestElement, ref int bestLength)
        {
            for (int row = 0; row < matrix.GetLongLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLongLength(1); col++)
                {
                    int direction = -1;

                    while (++direction < 4)
                    {
                        int _row = row + directions[direction, 0];
                        int _col = col + directions[direction, 1];
                        int currentLength = 1;

                        while (IsTraversable(matrix, row, col, _row, _col))
                        {
                            currentLength++;

                            if (currentLength > bestLength)
                            {
                                bestLength = currentLength;
                                bestElement = matrix[row, col];
                            }

                            _row += directions[direction, 0];
                            _col += directions[direction, 1];
                        }
                    }
                }
            }
        }

        static bool IsTraversable(string[,] matrix, int row, int col, int _row, int _col)
        {
            return _row >= 0 && _row < matrix.GetLongLength(0) &&
                   _col >= 0 && _col < matrix.GetLongLength(1) &&
                   matrix[_row, _col] == matrix[row, col];
        }
    }
}
