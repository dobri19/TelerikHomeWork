using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JediMeditate
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] jedi = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string keys = "MKP";
            var jediOrdered = Solve(jedi, keys);

            var builder = new StringBuilder();
            foreach (var key in keys)
            {
                var queue = jediOrdered[key];
                while (queue.Count > 0)
                {
                    builder.AppendFormat("{0} ", queue.Dequeue());
                }
            }

            Console.WriteLine(builder.ToString().Trim());
        }

        private static Dictionary<char, Queue<string>> Solve(string[] jedi, string keys)
        {
            var jediOrdered = new Dictionary<char, Queue<string>>();
            foreach (var key in keys)
            {
                jediOrdered[key] = new Queue<string>();
            }

            var jediInitial = jedi.ToList();
            jediInitial.ForEach(j => jediOrdered[j[0]].Enqueue(j));
            return jediOrdered;
        }
    }
}
