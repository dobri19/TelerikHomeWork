using System;
using System.Diagnostics;
using System.Linq;

namespace _01SelectSort
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //int[] arr1 = new int[] { 7, 4, 5, 4, 1, 0, 45, 3, 2, 7, 3 };
            //int[] arr2 = (int[])arr1.Clone();

            var rand = new Random();
            var arr = Enumerable.Range(1, 10000).Select(x => rand.Next(0, 1001)).ToArray();
            int[] arrCopy1 = (int[])arr.Clone();
            int[] arrCopy2 = (int[])arr.Clone();
            int[] arrCopy3 = (int[])arr.Clone();
            int[] arrCopy4 = (int[])arr.Clone();

            var sw = new Stopwatch();
            var elapsed = 0L;

            for (int i = 0; i < 1; i++)
            {
                sw.Restart();
                SelectionSort<int>.Sort(arrCopy2);
                elapsed += sw.ElapsedMilliseconds;
                Console.WriteLine("Selection:{0}", elapsed);
                elapsed = 0L;

                sw.Restart();
                BubbleSort<int>.Sort(arrCopy1);
                elapsed += sw.ElapsedMilliseconds;
                Console.WriteLine("Bubble: {0}", elapsed);
                elapsed = 0L;

                sw.Restart();
                InsertionMethods<int>.Sort(arr);
                elapsed += sw.ElapsedMilliseconds;
                Console.WriteLine("Insertion: {0}", elapsed);
                elapsed = 0L;

                var zzz = arrCopy3.ToList();
                sw.Restart();
                QuickSort<int>.QuickSortDobri(zzz, true);
                elapsed += sw.ElapsedMilliseconds;
                Console.WriteLine("Quick WithInsertion: {0}", elapsed);
                elapsed = 0L;

                var xxx = arrCopy4.ToList();
                sw.Restart();
                QuickSort<int>.QuickSortDobri(xxx, false);
                elapsed += sw.ElapsedMilliseconds;
                Console.WriteLine("Quick2: {0}", elapsed);
                elapsed = 0L;
            }

            //InsertionMethods<int>.Sort(arr1);

            //foreach (var item in arr2)
            //{
            //    Console.WriteLine(item);
            //}
        }
    }
}
