using System;

namespace P2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            long b1 = long.Parse(Console.ReadLine());
            long b2 = long.Parse(Console.ReadLine());
            long b3 = long.Parse(Console.ReadLine());
            long numberLayers = long.Parse(Console.ReadLine());

            Console.WriteLine(b1);
            Console.WriteLine(b2 + " " + b3);
            int count = 3;
            for (int i = 0; i < numberLayers - 2; i++)
            {
                for (int j = 0;  j < count;  j++)
                {
                    long b4 = b1 + b2 + b3;
                    Console.Write(b4);
                    if (j != count - 1)
                    {
                        Console.Write(" ");
                    }
                    
                    b1 = b2;
                    b2 = b3;
                    b3 = b4;
                }
                Console.WriteLine();
                count++;
            }
        }
    }
}
