using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01V3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int numberOfBuildings = int.Parse(Console.ReadLine());

            var heightOfBuildings = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var jumps = new int[numberOfBuildings];

            var st = new Stack<int>();

            for (int i = numberOfBuildings - 1; i >= 0; i--)
            {
                var currentBuilding = heightOfBuildings[i];

                while (st.Count > 0 && currentBuilding >= heightOfBuildings[st.Peek()])
                {
                    st.Pop();
                }

                if (st.Count > 0)
                {
                    jumps[i] = jumps[st.Peek()] + 1;
                }
                st.Push(i);
            }

            Console.WriteLine(jumps.Max());
            Console.WriteLine(string.Join(" ", jumps));
        }
    }
}
