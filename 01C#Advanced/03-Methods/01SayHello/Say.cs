using System;

namespace _01SayHello
{
    public class Say
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            PrintHello(name);
        }

        public static void PrintHello(string name)
        {
            Console.WriteLine("Hello, {0}!", name);
        }
    }
}
