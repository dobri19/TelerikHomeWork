using System;

namespace LargestArea
{
    public class Matrix
    {
        private static int max = 0; // Longest sequence
        private static int[,] matrix; // Nums
        private static int rows, cols;
        private static int curSeq = 0;  //Sequence now
        private static bool[,] usedNums;  // Array where if cell is true then the num at cells position is used

        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            rows = int.Parse(input[0]);
            cols = int.Parse(input[1]);
            matrix = new int[rows, cols];
            usedNums = new bool[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                input = Console.ReadLine().Split(' ');
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = int.Parse(input[col]);
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    curSeq = 0;
                    FindChilders(matrix[row, col], row, col);
                    if (curSeq > max)
                    {
                        max = curSeq;
                    }
                }
            }

            Console.WriteLine(max);
        }

        //Recursion
        static void FindChilders(int num, int row, int col)
        {
            curSeq++;
            usedNums[row, col] = true;

            //Check Down Cell
            if (row + 1 < rows)
            {
                if (matrix[row + 1, col] == num && usedNums[row + 1, col] == false)
                {
                    FindChilders(num, row + 1, col);
                }
            }

            //Check Up Cell
            if (row - 1 >= 0)
            {
                if (matrix[row - 1, col] == num && usedNums[row - 1, col] == false)
                {
                    FindChilders(num, row - 1, col);
                }
            }

            //Check Left Cell
            if (col - 1 >= 0)
            {
                if (matrix[row, col - 1] == num && usedNums[row, col - 1] == false)
                {
                    FindChilders(num, row, col - 1);
                }
            }

            //Check Right Cell
            if (col + 1 < cols)
            {
                if (matrix[row, col + 1] == num && usedNums[row, col + 1] == false)
                {
                    FindChilders(num, row, col + 1);
                }
            }
        }
    }
}
