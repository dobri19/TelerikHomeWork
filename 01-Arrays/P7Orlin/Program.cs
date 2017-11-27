using System;
using System.Linq;

namespace P7Orlin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] dims = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int[,] chessBoard = new int[dims[0], dims[1]];

            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                var thisRowFirstElement = chessBoard.GetLength(0) - row - 1;

                for (int col = 0; col < chessBoard.GetLength(1); col++)
                {
                    chessBoard[row, col] = (thisRowFirstElement + col) * 3;
                }
            }

            int[] position = { chessBoard.GetLength(0) - 1, 0 };

            var numberOfMoves = int.Parse(Console.ReadLine());

            long sum = 0;

            for (int i = 0; i < numberOfMoves; i++)
            {
                string move = Console.ReadLine();

                string direction = move.Substring(0, 2);
                int numberOfSteps = int.Parse(move.Substring(3));

                switch (direction)
                {
                    case "UR":
                    case "RU":

                        for (int j = 1; j < numberOfSteps; j++)
                        {

                            if ((position[0] > 0) && (position[1] < chessBoard.GetLength(1) - 1))
                            {
                                position[0]--;
                                position[1]++;

                                sum += chessBoard[position[0], position[1]];
                                chessBoard[position[0], position[1]] = 0;
                            }
                            else
                            {
                                break;
                            }
                        }

                        break;

                    case "UL":
                    case "LU":

                        for (int j = 1; j < numberOfSteps; j++)
                        {

                            if ((position[0] > 0) && (position[1] > 0))
                            {
                                position[0]--;
                                position[1]--;

                                sum += chessBoard[position[0], position[1]];
                                chessBoard[position[0], position[1]] = 0;
                            }
                            else
                            {
                                break;
                            }
                        }

                        break;

                    case "DR":
                    case "RD":

                        for (int j = 1; j < numberOfSteps; j++)
                        {

                            if ((position[0] < chessBoard.GetLength(0) - 1) && (position[1] < chessBoard.GetLength(1) - 1))
                            {
                                position[0]++;
                                position[1]++;

                                sum += chessBoard[position[0], position[1]];
                                chessBoard[position[0], position[1]] = 0;
                            }
                            else
                            {
                                break;
                            }
                        }

                        break;

                    case "DL":
                    case "LD":

                        for (int j = 1; j < numberOfSteps; j++)
                        {

                            if ((position[0] < chessBoard.GetLength(0) - 1) && (position[1] > 0))
                            {
                                position[0]++;
                                position[1]--;

                                sum += chessBoard[position[0], position[1]];
                                chessBoard[position[0], position[1]] = 0;
                            }
                            else
                            {
                                break;
                            }
                        }

                        break;

                    default:
                        break;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
