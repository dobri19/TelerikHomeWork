using System;
using System.Collections.Generic;

namespace Task00PathOne
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //int n = int.Parse(Console.ReadLine());
            var shortest = ShortestSequenceOfOperations(15, 1);

            Console.WriteLine(string.Join(", ", shortest));
        }

        private static SortedSet<int> ShortestSequenceOfOperations(int start, int end)
        {
            var set = new SortedSet<int>();
            set.Add(end);
            set.Add(start);

            while (start > end)
            {
                if ((start % 2 == 0))
                {
                    start = start / 2;
                    set.Add(start);
                }

                else if ((start / 2 >= start) && (end % 2 == 1))
                {
                    end--;
                    set.Add(end);

                    end = end / 2;
                    set.Add(end);
                }

                else if (end - 2 >= start)
                {
                    end -= 2;
                    set.Add(end);
                }
                else
                {
                    end--;
                    set.Add(end);
                }
            }

            return set;
        }
    }
}
