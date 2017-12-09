using System;
using System.Collections.Generic;
using System.Linq;

namespace P3Sequence
{
    public class Sequence
    {
        public static void Main()
        {
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

            int longestSequence = GetLongestSequence(matrix);
            Console.WriteLine(longestSequence);
        }
        public static int GetLongestSequence(string[,] matrix)
        {
            int maxCount = 0;
            string bestString = string.Empty;

            GetLongestSequenceInRow(matrix, maxCount, bestString);
            GetLongestSequenceInCol(matrix, maxCount, bestString);
            GetLongestSequenceInDiagonal(matrix, maxCount, bestString);

            return maxCount;
        }

        private static int GetLongestSequenceInRow(string[,] matrix, int maxCount, string bestString)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string currentString = matrix[row, 0];
                int count = 1;

                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    CountEqualElements(matrix[row, col], currentString, count, maxCount, bestString);
                }
            }

            return maxCount;
        }

        private static int GetLongestSequenceInCol(string[,] matrix, int maxCount, string bestString)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                string currentString = matrix[0, col];
                int count = 1;

                for (int row = 1; row < matrix.GetLength(0); row++)
                {
                    CountEqualElements(matrix[row, col], currentString, count, maxCount, bestString);
                }
            }

            return maxCount;
        }

        private static int GetLongestSequenceInDiagonal(string[,] matrix, int maxCount, string bestString)
        {
            string currentString = matrix[0, 0];
            int count = 1;

            for (int currentCol = 0; currentCol < matrix.GetLength(1); currentCol++)
            {
                currentString = matrix[0, currentCol];
                count = 1;
                for (int row = 1, col = currentCol + 1; row < matrix.GetLength(0) && col < matrix.GetLength(1); row++, col++)
                {
                    CountEqualElements(matrix[row, col], currentString, count, maxCount, bestString);
                }

                currentString = matrix[matrix.GetLength(0) - 1, currentCol];
                count = 1;

                for (int row = matrix.GetLength(0) - 2, col = currentCol + 1; row >= 0 && col < matrix.GetLength(1); row--, col++)
                {
                    CountEqualElements(matrix[row, col], currentString, count, maxCount, bestString);
                }
            }

            for (int currentRow = 1; currentRow < matrix.GetLength(0) - 1; currentRow++)
            {
                currentString = matrix[currentRow, 0];
                count = 1;

                for (int row = currentRow + 1, col = 1; row < matrix.GetLength(0) && col < matrix.GetLength(1) - 1; row++, col++)
                {
                    CountEqualElements(matrix[row, col], currentString, count, maxCount, bestString);
                }

                currentString = matrix[matrix.GetLength(0) - 1 - currentRow, 0];
                count = 1;

                for (int row = matrix.GetLength(0) - 2 - currentRow, col = 1; row >= 0 && col < matrix.GetLength(1) - 1; row--, col++)
                {
                    CountEqualElements(matrix[row, col], currentString, count, maxCount, bestString);
                }
            }

            return maxCount;
        }

        private static void CountEqualElements(string first, string second, int count, int maxCount, string bestString)
        {
            if (first == second)
            {
                count++;

                if (count > maxCount)
                {
                    maxCount = count;
                    bestString = second;
                }
            }
            else
            {
                count = 1;
                second = first;
            }
        }
    }
}
