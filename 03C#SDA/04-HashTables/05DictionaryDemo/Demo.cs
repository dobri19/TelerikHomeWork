using System;
using System.Collections.Generic;

namespace _05DictionaryDemo
{
    public class Demo
    {
        public static void Main(string[] args)
        {
            var table = new Dictionary<string, int>();

            table.Add("Pesho", 6);
            table.Add("Ivan", 3);
            table.Add("Cuki", 5);
            table.Add("Doncho", 4);
            table.Add("Pancho", 3);
            table.Remove("Cuki");
            table.Add("Doncho2", 4);
            table.Add("Pancho2", 3);

            //for (int i = 0; i < 100; i++)
            //{
            //    table.Add(i, i);
            //}
            //table.Remove(50);
            //table.Add(-4, 6);

            foreach (var pair in table)
            {
                //Console.WriteLine("{0}", pair.Value.GetHashCode());
                Console.WriteLine(pair.Key.GetHashCode());
                Console.WriteLine("{0} : {1}", pair.Key, pair.Value);
            }
        }
    }
}
