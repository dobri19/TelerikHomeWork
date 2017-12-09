using System;

namespace P1
{
    public class FillTheMatrix
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char ch = char.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];
            int count = 1;

            if (ch == 'a')
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        matrix[j, i] = count;
                        count++;
                    }
                }
            }

            if (ch == 'b')
            {
                for (int i = 0; i < n; i++)
                {
                    if (i % 2 == 0)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            matrix[j, i] = count;
                            count++;
                        }
                    }
                    else
                    {
                        for (int k = n - 1; k >= 0; k--)
                        {
                            matrix[k, i] = count;
                            count++;
                        }
                    }
                }
            }

            if (ch == 'c')
            {
                for (int row = n - 1; row >= 0; row--)
                {
                    for (int secRow = row, col = 0; secRow < n; secRow++, col++)
                    {
                        matrix[secRow, col] = count++;
                    }
                }
                for (int col = 1; col < n; col++)
                {
                    for (int secCol = col, row = 0; secCol < n; secCol++, row++)
                    {
                        matrix[row, secCol] = count++;
                    }
                }
            }

            //if (ch == 'd')
            //{
            //    for (int i = 0; i < n; i++)
            //    {
            //        for (int j = i; j < n - i; j++)
            //        {
            //            matrix[j, i] = count;
            //            count++;
            //        }
            //        for (int j = i + 1; j < n - i; j++)
            //        {
            //            matrix[(n - i - 1), j] = count;
            //            count++;
            //        }
            //        for (int j = (n - i - 1); j > i; j--)
            //        {
            //            matrix[j - 1, (n - i - 1)] = count;
            //            count++;
            //        }
            //        for (int j = (n - i - 2); j > i; j--)
            //        {
            //            matrix[i, j] = count;
            //            count++;
            //        }
            //    }
            //}

            if (ch == 'd')
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
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j != n - 1)
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
