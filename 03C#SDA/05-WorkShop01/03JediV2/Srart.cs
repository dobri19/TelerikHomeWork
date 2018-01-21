using System;
using System.Collections.Generic;
using System.Linq;

namespace JediV2
{
    public class Srart
    {
        //public static int CompareJedi(string x, string y)
        //{
        //    if (x[0] == 'M')
        //    {
        //        return -1;
        //    }
        //    if (y[0] == 'M')
        //    {
        //        return 1;
        //    }
        //    if (x[0] == 'K')
        //    {
        //        return -1;
        //    }
        //    if (y[0] == 'K')
        //    {
        //        return 1;
        //    }
        //    return -1;
        //}

        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            //var jedis = Console.ReadLine().Split(' ').ToList();

            //short answer
            //var jedis = Console.ReadLine()
            //                            .Split(' ')
            //                            .GroupBy(x => x[0])
            //                            .OrderBy(x => x.Key == 'M' ? 0 : (x.Key == 'K' ? 1 : 2))
            //                            .SelectMany(x => x);
                                        //.ToList();
            Console.WriteLine(Console.ReadLine().Split(' ').GroupBy(x => x[0])
                .OrderBy(x => x.Key == 'M' ? 0 : (x.Key == 'K' ? 1 : 2)).SelectMany(x => x).ToList());

            // true but with random order
            //jedis.Sort(CompareJedi);
            //Console.WriteLine(string.Join(" ", jedis));

            //var mList = new List<string>();
            //var kList = new List<string>();
            //var pList = new List<string>();

            //foreach (var jedi in jedis)
            //{
            //    if (jedi[0] == 'M')
            //    {
            //        mList.Add(jedi);
            //    }
            //    else if (jedi[0] == 'K')
            //    {
            //        kList.Add(jedi);
            //    }
            //    else if (jedi[0] == 'P')
            //    {
            //        pList.Add(jedi);
            //    }
            //}

            //mList.AddRange(kList);
            //mList.AddRange(pList);

            //Console.WriteLine(string.Join(" ", mList));
        }
    }
}
