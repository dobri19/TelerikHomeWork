using System;
using System.Collections.Generic;
using System.Linq;

namespace _04V4Mine
{
    public class BFDFS
    {
        private static int[] Rows = { 1, -1, 0, 0 };
        private static int[] Cols = { 0, 0, -1, 1 };

        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];

            int[,] graph = new int[rows, cols];
            bool[,] isVisited = new bool[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    graph[i, j] = numbers[j];
                }
            }

            int largestArea = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (!isVisited[i, j])
                    {
                        int area = Bfs(i, j, graph, isVisited);
                        if (largestArea < area)
                        {
                            largestArea = area;
                        }
                    }
                }
            }

            Console.WriteLine(largestArea);
        }

        private static int Bfs(int row, int col, int[,] graph, bool[,] isVisited)
        {
            int counter = 0;
            Node current = new Node();
            current.Row = row;
            current.Col = col;
            isVisited[current.Row, current.Col] = true;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(current);

            while (queue.Count > 0)
            {
                counter++;
                var last = queue.Dequeue();

                foreach (Node neighbour in GetNeighbours(last, graph))
                {
                    if (!isVisited[neighbour.Row, neighbour.Col])
                    {
                        queue.Enqueue(neighbour);
                        isVisited[neighbour.Row, neighbour.Col] = true;
                    }
                }
            }

            return counter;
        }

        private static int Dfs(int row, int col, int[,] graph, bool[,] isVisited)
        {
            int counter = 0;
            Node current = new Node();
            current.Row = row;
            current.Col = col;
            isVisited[current.Row, current.Col] = true;

            Stack<Node> stack = new Stack<Node>();
            stack.Push(current);

            while (stack.Count > 0)
            {
                Node node = stack.Pop();
                counter++;

                foreach (Node neighbour in GetNeighbours(node, graph))
                {
                    if (!isVisited[neighbour.Row, neighbour.Col])
                    {
                        stack.Push(neighbour);
                        isVisited[neighbour.Row, neighbour.Col] = true;
                    }
                }
            }

            return counter;
        }

        private static int RecursiveDfs(int row, int col, int[,] graph, bool[,] visited)
        {
            int count = 1;
            Node node = new Node() { Row = row, Col = col };
            visited[node.Row, node.Col] = true;

            foreach (Node neighbour in GetNeighbours(node, graph))
            {
                if (!visited[neighbour.Row, neighbour.Col])
                {
                    count += RecursiveDfs(neighbour.Row, neighbour.Col, graph, visited);
                }
            }

            return count;
        }

        private static IEnumerable<Node> GetNeighbours(Node node, int[,] graph)
        {
            List<Node> neighbours = new List<Node>();
            for (int i = 0; i < Rows.Length; i++)
            {
                Node neighbour = new Node() { Row = node.Row + Rows[i], Col = node.Col + Cols[i] };
                if (IsValid(neighbour.Row, neighbour.Col, graph.GetLength(0), graph.GetLength(1))
                 && graph[node.Row, node.Col] == graph[neighbour.Row, neighbour.Col])
                {
                    neighbours.Add(neighbour);
                }
            }

            return neighbours;
        }

        private static bool IsValid(int row, int col, int rows, int cols)
        {
            return row > -1 && row < rows && col > -1 && col < cols;
        }
    }

    public class Node
    {
        public int Row { get; set; }

        public int Col { get; set; }
    }
}
