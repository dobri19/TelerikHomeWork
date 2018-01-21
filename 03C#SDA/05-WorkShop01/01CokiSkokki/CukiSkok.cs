using System;
using System.Collections.Generic;
using System.Linq;

namespace CokiSkokki
{
    public class CukiSkok
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] buildings = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            LinkedList<int> jumpsPerBuilding = new LinkedList<int>();
            int[] maxJumpsMatrix = new int[n];
            int totalJumps = 0;
            int maxHeight = buildings.Max();

            for (int i = 0; i < n; i++)
            {
                int counter = 0;
                int currentBuilding = buildings[i];

                for (int j = i + 1; j < n; j++)
                {
                    if (currentBuilding == maxHeight)
                    {
                        break;
                    }
                    if (currentBuilding < buildings[j])
                    {
                        counter++;
                        currentBuilding = buildings[j];
                    }
                }
                if (counter > totalJumps)
                {
                    totalJumps = counter;
                }
                jumpsPerBuilding.AddLast(counter);
            }

            Console.WriteLine(totalJumps);
            Console.WriteLine(string.Join(" ", jumpsPerBuilding));


            //var d = new int[buildings.Length];
            //var s = new Stack<int>();

            //for (var i = buildings.Length - 1; i >= 0; i--)
            //{
            //    var current = buildings[i];

            //    while (s.Count > 0 && current >= buildings[s.Peek()])
            //    {
            //        s.Pop();
            //    }

            //    if (s.Count > 0)
            //    {
            //        d[i] = d[s.Peek()] + 1;
            //    }
            //    s.Push(i);
            //}

            //Console.WriteLine(d.Max());
            //Console.WriteLine(string.Join(" ", d));
        }
    }
}
