using System;

namespace Second
{
    public class StartUpTwo
    {
        public static void Main(string[] args)
        {
            long brickOne = long.Parse(Console.ReadLine());
            long brickTwo = long.Parse(Console.ReadLine());
            long brickThree = long.Parse(Console.ReadLine());
            long numberLayers = long.Parse(Console.ReadLine());

            Console.WriteLine(brickOne);
            Console.WriteLine(brickTwo + " " + brickThree);
            int elemenstInLayer = 2;

            while (numberLayers > 2)
            {
                string layerToPrint = "";
                elemenstInLayer++;
                for (int i = 0; i < elemenstInLayer; i++)
                {
                    long nextBrick = brickOne + brickTwo + brickThree;
                    layerToPrint += nextBrick + " ";
                    brickOne = brickTwo;
                    brickTwo = brickThree;
                    brickThree = nextBrick;
                }
                if (layerToPrint[layerToPrint.Length - 1] == ' ')
                {
                    layerToPrint = layerToPrint.Remove(layerToPrint.Length - 1, 1);
                }
                Console.WriteLine(layerToPrint);
                numberLayers--;
            }


        }
    }
}
