using System;
using System.Linq;

namespace P7
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string dimensions = Console.ReadLine();
            int[] arrDim = dimensions.Split(' ').Select(int.Parse).ToArray();
            int n = arrDim[0];
            int m = arrDim[1];
            int[,] matrix = new int[n, m];
            int count = 0;
            int count2 = 3;

            for (int j = 0; j < m; j++)
            {
                for (int i = n - 1; i >= 0; i--)
                {
                    matrix[i, j] = count;
                    count += 3;
                }
                count2 += 3;
                count = count2;
            }

            int direct = int.Parse(Console.ReadLine());

            string[,] matrixDir = new string[direct, 2];
            for (int i = 0; i < direct; i++)
            {
                string[] columns = Console.ReadLine().Split(' ').ToArray();
                matrixDir[i, 0] = columns[0];
                matrixDir[i, 1] = columns[1];
            }

            int sum = 0;
            int currrentPos = matrix[n, m];
            for (int i = 0; i < direct; i++)
            {
                if (matrixDir[i, 0] == "RU" || matrixDir[i, 0] == "UR")
                {
                    for (int j = 0; j < int.Parse(matrixDir[i, 1]); j++)
                    {
                        sum += matrix[];
                    }
                }
                else if (matrixDir[i, 0] == "LU" || matrixDir[i, 0] == "UL")
                {

                }
                else if (matrixDir[i, 0] == "DL" || matrixDir[i, 0] == "LD")
                {

                }
                else if (matrixDir[i, 0] == "DR" || matrixDir[i, 0] == "RD")
                {

                }
            }

            //PrintMatrix(matrix);
            //PrintMatrix(matrixDir);
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j != matrix.GetLength(1))
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

        private static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j != matrix.GetLength(1))
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
