using System;

namespace Q01Fill
{
    public class FillMatrix
    {
        static int count = 1;

        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char ch = char.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            switch (ch)
            {
                case 'a':
                    FillA(matrix);
                    break;
                case 'b':
                    FillB(matrix);
                    break;
                case 'c':
                    FillC(matrix);
                    break;
                case 'd':
                    FillD(matrix);
                    break;
                default:
                    break;
            }
            PrintMatrix(matrix);
        }

        private static void FillA(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[j, i] = count;
                    count++;
                }
            }
        }

        private static void FillB(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[j, i] = count;
                        count++;
                    }
                }
                else
                {
                    for (int k = matrix.GetLength(1) - 1; k >= 0; k--)
                    {
                        matrix[k, i] = count;
                        count++;
                    }
                }
            }
        }

        private static void FillC(int[,] matrix)
        {
            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                for (int secRow = row, col = 0; secRow < matrix.GetLength(0); secRow++, col++)
                {
                    matrix[secRow, col] = count++;
                }
            }
            for (int col = 1; col < matrix.GetLength(0); col++)
            {
                for (int secCol = col, row = 0; secCol < matrix.GetLength(0); secCol++, row++)
                {
                    matrix[row, secCol] = count++;
                }
            }
        }

        private static void FillD(int[,] matrix)
        {
            int row = 0;
            int col = 0;
            bool isDown = true;
            bool isRight = false;
            bool isUp = false;
            bool isLeft = false;
            int counter = 1;

            while (counter <= matrix.GetLength(0) * matrix.GetLength(0))
            {
                matrix[row, col] = counter;
                if (isDown)
                {
                    if (row + 1 >= matrix.GetLength(0) || matrix[row + 1, col] != 0)
                    {
                        isDown = false;
                        isRight = true;
                        col++;
                    }
                    else
                    {
                        row++;
                    }
                }
                else if (isRight)
                {
                    if (col + 1 >= matrix.GetLength(1) || matrix[row, col + 1] != 0)
                    {
                        isRight = false;
                        isUp = true;
                        row--;
                    }
                    else
                    {
                        col++;
                    }
                }
                else if (isUp)
                {
                    if (row - 1 < 0 || matrix[row - 1, col] != 0)
                    {
                        isUp = false;
                        isLeft = true;
                        col--;
                    }
                    else
                    {
                        row--;
                    }
                }
                else if (isLeft)
                {
                    if (col - 1 < 0 || matrix[row, col - 1] != 0)
                    {
                        isLeft = false;
                        isDown = true;
                        row++;
                    }
                    else
                    {
                        col--;
                    }
                }
                counter++;
            }
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j != matrix.GetLength(1) - 1)
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
