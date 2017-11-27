using System;
using System.Collections.Generic;
using System.Linq;

namespace T3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int maxCarrots = int.MinValue;
            int[] fieldOfCarrots = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.None).Select(int.Parse).ToArray();
            int sequences = int.Parse(Console.ReadLine());

            for (int i = 0; i < sequences; i++)
            {
                int z = 0;
                int currentCarrots = 0;
                int k = 0;
                int[] directions = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.None).Select(int.Parse).ToArray();
                List<int> beenThere = new List<int>();
                for (int j = 0; j >= 0 && j < fieldOfCarrots.Length; j += z)
                {
                    if (beenThere.Contains(j))
                    {
                        break;
                    }
                    else
                    {
                        beenThere.Add(j);
                    }

                    currentCarrots += fieldOfCarrots[j];
                    if (k == (directions.Length))
                    {
                        k = 0;
                    }
                    z = directions[k];
                    k++;
                }

                if (currentCarrots > maxCarrots)
                {
                    maxCarrots = currentCarrots;
                }
            }

            Console.WriteLine(maxCarrots);
        }
    }
}
