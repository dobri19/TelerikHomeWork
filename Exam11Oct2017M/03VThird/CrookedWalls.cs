using System;
using System.Collections.Generic;
using System.Linq;

namespace VThird
{
    public class CrookedWalls
    {
        public static void Main()
        {
            List<long> listOfWallsHeights = Console.ReadLine().Split(' ').Select(long.Parse).ToList();
            PrintSumEvenDistancesWalls(listOfWallsHeights);
        }

        private static void PrintSumEvenDistancesWalls(List<long> listOfWallsHeights)
        {
            long distanceBetweenWalls = 0;
            long sumOfEvenDistances = 0;
            int step = 0;

            for (int j = 1; j < listOfWallsHeights.Count; j += step)
            {
                distanceBetweenWalls = Math.Max(listOfWallsHeights[j], listOfWallsHeights[j - 1]) - Math.Min(listOfWallsHeights[j], listOfWallsHeights[j - 1]);
                if (distanceBetweenWalls % 2 == 0)
                {
                    sumOfEvenDistances += distanceBetweenWalls;
                }
                if (distanceBetweenWalls % 2 == 0)
                {
                    step = 2;
                }
                else
                {
                    step = 1;
                }
            }

            Console.WriteLine(sumOfEvenDistances);
        }
    }
}
