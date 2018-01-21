using System;

namespace _04LargestAreaV2
{
    public class DFS
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int rows = int.Parse(input[0]);
            int cols = int.Parse(input[1]);
            int[,] matrix = new int[rows, cols];
            bool[,] usedNums = new bool[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                input = Console.ReadLine().Split(' ');
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = int.Parse(input[col]);
                }
            }

            int bestCount = 0;
            int indexRow = 0;
            int indexCol = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (!usedNums[row, col])
                    {
                        int count = DepthFirstSearch(matrix, row, col, usedNums);
                        if (bestCount < count)
                        {
                            bestCount = count;
                            indexRow = row;
                            indexCol = col;
                        }
                    }

                }
            }
            //Console.WriteLine("The len of largest area in matrix is {0}", bestCount);
            //Console.WriteLine("The element is {2} on position {0},{1} ", indexRow, indexCol, matrix[indexRow, indexCol]);
            Console.WriteLine(bestCount);

        }

        public static int DepthFirstSearch(int[,] array, int row, int col, bool[,] calc)
        {
            int result = 1;
            calc[row, col] = true;
            if ((row - 1 >= 0) && (array[row - 1, col] == array[row, col]) && !calc[row - 1, col])
            {
                result += DepthFirstSearch(array, row - 1, col, calc);
            }
            if ((row + 1 < array.GetLength(0)) && (array[row + 1, col] == array[row, col]) && !calc[row + 1, col])
            {
                result += DepthFirstSearch(array, row + 1, col, calc);
            }
            if ((col - 1 >= 0) && (array[row, col - 1] == array[row, col]) && !calc[row, col - 1])
            {
                result += DepthFirstSearch(array, row, col - 1, calc);
            }
            if ((col + 1 < array.GetLength(1)) && (array[row, col + 1] == array[row, col]) && !calc[row, col + 1])
            {
                result += DepthFirstSearch(array, row, col + 1, calc);
            }
            return result;
        }
    }
}
