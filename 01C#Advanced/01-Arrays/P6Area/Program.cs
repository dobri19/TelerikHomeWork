using System;
using System.Linq;

namespace P6Area
{
    public class Program
    {
        static int bestLength = 0;
        static int bestNumber = 0;
        static int currentLength = 0;
        static int currentNumber = 0;
        static int rows;
        static int cols;
        // static bool[,] isVisited;

        public static void Main()
        {
            string dim = Console.ReadLine();
            int[] arrDim = dim.Split(' ').Select(int.Parse).ToArray();
            rows = arrDim[0];
            cols = arrDim[1];
            int[][] matrix = new int[rows][];

            // isVisited = new bool[arrDim[0], arrDim[1]];
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            }
            FindBestArea(matrix);
        }

        public static void FindBestArea(int[][] matrix)
        {
            bestLength = 0;
            bestNumber = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    currentNumber = matrix[row][col];
                    currentLength = 0;
                    GetArea(row, col, matrix);
                    if (currentLength > bestLength)
                    {
                        bestLength = currentLength;
                        bestNumber = currentNumber;
                    }
                }
            }
            Console.WriteLine(bestLength);
        }

        public static void GetArea(int row, int col, int[][] matrix)
        {
            if (row < 0 || row >= rows ||
                col < 0 || col >= cols || matrix[row][col] == 0)
                return;
            //if (matrix[row, col] != currentNumber)
            //    return;
            if (matrix[row][col] == currentNumber)
            {
                matrix[row][col] = 0;
                //isVisited[row, col] = true;
                currentLength++;
                GetArea(row - 1, col, matrix);
                GetArea(row + 1, col, matrix);
                GetArea(row, col - 1, matrix);
                GetArea(row, col + 1, matrix);
            }
        }
    }
}
