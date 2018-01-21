using System;

namespace HashImplementation
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var table = new HashDictionary<string, int>();

            table.Add("Pesho", 4);
            table.Add("Rosho", 3);
            table.Add("Stamat", 6);
            table.Add("Maria", 5);

            Console.WriteLine(table.Count);
            Console.WriteLine("Is Stamat here? " + table.ContainsKey("Stamat"));
            Console.WriteLine("Is Pencho here? " + table.ContainsKey("Pencho"));

            table.DeleteKey("Stamat");
            Console.WriteLine("Is Stamat here? " + table.ContainsKey("Stamat"));
            Console.WriteLine(table.Count);

            foreach (var pair in table)
            {
                Console.WriteLine(pair.Key + " --> " + pair.Value);
            }
        }
    }
}
