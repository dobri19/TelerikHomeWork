using System;
using System.Linq;

namespace Third
{
    public class StartUpThree
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] zzz = input.Split(' ').ToArray();
            long[] wallsHeight = new long[zzz.Length];
            for (int i = 0; i < zzz.Length; i++)
            {
                wallsHeight[i] = long.Parse(zzz[i]);
            }

            long dis = 0;
            long sum = 0;
            int step = 0;
            for (int j = 1; j < wallsHeight.Length; j+=step)
            {
                dis = Math.Max(wallsHeight[j], wallsHeight[j - 1]) - Math.Min(wallsHeight[j], wallsHeight[j - 1]);
                if (dis % 2 == 0)
                {
                    sum += dis;
                }
                if (dis % 2 == 0)
                {
                    step = 2;
                }
                else
                {
                    step = 1;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
