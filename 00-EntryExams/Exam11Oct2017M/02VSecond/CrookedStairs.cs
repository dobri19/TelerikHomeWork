using System;

namespace VSecond
{
    public class CrookedStairs
    {
        public static void Main()
        {
            long brickN1 = long.Parse(Console.ReadLine());
            long brickN2 = long.Parse(Console.ReadLine());
            long brickN3 = long.Parse(Console.ReadLine());
            int numberLayers = int.Parse(Console.ReadLine());

            PrintCrookedStairs(brickN1, brickN2, brickN3, numberLayers);
        }

        private static void PrintCrookedStairs(long brickNminus3, long brickNminus2, long brickNminus1, int numberLayers)
        {
            string stairs = string.Empty;
            stairs += brickNminus3 + "\n"; // layer one
            stairs += brickNminus2 + " " + brickNminus1; // layer two
            int layersLeftToPrint = numberLayers - 2;
            int elementsInCurrentLayer = 3;

            while (layersLeftToPrint > 0)
            {
                stairs += "\n";
                for (int i = 0; i < elementsInCurrentLayer; i++)
                {
                    long brickN = brickNminus3 + brickNminus2 + brickNminus1;

                    if (i == elementsInCurrentLayer - 1)
                    {
                        stairs += brickN;
                    }
                    else
                    {
                        stairs += brickN + " ";
                    }

                    brickNminus3 = brickNminus2;
                    brickNminus2 = brickNminus1;
                    brickNminus1 = brickN;
                }
                elementsInCurrentLayer++;
                layersLeftToPrint--;
            }

            Console.WriteLine(stairs);
        }
    }
}
