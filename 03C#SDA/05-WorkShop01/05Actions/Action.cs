using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace Actions
{
    public class Action
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int numbers = int.Parse(input[0]);
            int orders = int.Parse(input[1]);
            LinkedList<int> list = new LinkedList<int>();

            for (int i = 0; i < numbers; i++)
            {
                list.AddLast(i);
            }

            for (int i = 1; i <= orders; i++)
            {
                string[] ab = Console.ReadLine().Split(' ');
                int a = int.Parse(ab[0]);
                int b = int.Parse(ab[1]);

                int indexBig = list.Select((item, inx) => new { item, inx })
                                    .First(x => x.item == a).inx;
                int indexSmall = list.Select((item, inx) => new { item, inx })
                                    .First(x => x.item == b).inx;
                if (indexBig > indexSmall)
                {
                    list.Remove(b);
                    LinkedListNode<int> ccc = list.Find(a);
                    while (ccc.Next != null && ccc.Next.Value < b)
                    {
                        ccc = ccc.Next;
                    }
                    list.AddAfter(ccc, b);
                }
            }

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
