using System;

namespace P03
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            GenericList<int> GenieList = new GenericList<int>();

            Console.WriteLine(GenieList.ToString());
            Console.WriteLine("Count: {0}", GenieList.Count);
            Console.WriteLine("Capacity: {0}", GenieList.Capacity);
            Console.WriteLine();

            GenieList.Add(1);
            GenieList.Add(2);
            GenieList.Add(3);
            GenieList.Add(4);
            Console.WriteLine(GenieList.ToString());
            Console.WriteLine("Count: {0}", GenieList.Count);
            Console.WriteLine("Capacity: {0}", GenieList.Capacity);
            Console.WriteLine();

            GenieList.Clear();
            GenieList.InsertAt(0, -50);
            GenieList.InsertAt(0, 4);
            GenieList.InsertAt(0, 3);
            GenieList.InsertAt(0, 2);
            GenieList.InsertAt(0, -100);
            GenieList.InsertAt(1, 100);
            GenieList.InsertAt(2, 500);
            Console.WriteLine(GenieList.ToString());
            Console.WriteLine();

            GenieList.RemoveAt(0);
            GenieList.RemoveAt(GenieList.Count - 1);
            Console.WriteLine(GenieList.ToString());
            Console.WriteLine();

            Console.WriteLine("Contain element 2: {0}", GenieList.Contains(2));
            Console.WriteLine("Contain element 100: {0}", GenieList.Contains(1000));
            Console.WriteLine("Index of element 3: {0}", GenieList.IndexOf(3));
            Console.WriteLine();

            Console.WriteLine("Min: {0}", GenieList.Min());
            Console.WriteLine("Max: {0}", GenieList.Max());
        }
    }
}
