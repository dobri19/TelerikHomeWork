namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Program
    {
        internal static void Main(string[] args)
        {
            //var collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });
            //Console.WriteLine("All items before sorting:");
            //collection.PrintAllItemsOnConsole();
            //Console.WriteLine();

            //Console.WriteLine("Linear search 101:");
            //Console.WriteLine(collection.LinearSearch(101));
            //Console.WriteLine();

            //Console.WriteLine("Binary search 101:");
            //Console.WriteLine(collection.BinarySearch(101));
            //Console.WriteLine();

            //Console.WriteLine("SelectionSorter result:");
            //collection.Sort(new SelectionSorter<int>());
            //collection.PrintAllItemsOnConsole();
            //Console.WriteLine();

            //collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });
            //Console.WriteLine("Quicksorter result:");
            //collection.Sort(new Quicksorter<int>());
            //collection.PrintAllItemsOnConsole();
            //Console.WriteLine();

            //collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });
            //Console.WriteLine("QuickTry result:");
            //collection.Sort(new Quicksorter<int>());
            //collection.PrintAllItemsOnConsole();
            //Console.WriteLine();

            //collection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 101 });
            //Console.WriteLine("MergeSorter result:");
            //collection.Sort(new MergeSorter<int>());
            //collection.PrintAllItemsOnConsole();
            //Console.WriteLine();

            //Console.WriteLine("Shuffle:");
            //collection.Shuffle();
            //collection.PrintAllItemsOnConsole();
            //Console.WriteLine();

            //Console.WriteLine("Shuffle again:");
            //collection.Shuffle();
            //collection.PrintAllItemsOnConsole();

            var rand = new Random();
            var arr = Enumerable.Range(1, 10000).Select(x => rand.Next(0, 1001));
            var collection = new SortableCollection<int>(arr);
            Stopwatch watch = new Stopwatch();
            var elaps = 0L;

            Console.WriteLine("SelectionSorter");
            for (int i = 0; i < 1; i++)
            {
                watch.Start();
                collection.Sort(new SelectionSorter<int>());
                watch.Stop();
                arr = Enumerable.Range(1, 10000).Select(x => rand.Next(0, 1001));
                collection = new SortableCollection<int>(arr);
                elaps += watch.ElapsedMilliseconds;
                Console.WriteLine("Measured time: " + elaps + " ms.");
                watch.Reset();
                elaps = 0;
            }

            Console.WriteLine();
            Console.WriteLine("InsertionSorter");
            for (int i = 0; i < 1; i++)
            {
                watch.Start();
                collection.Sort(new InsertionSorter<int>());
                watch.Stop();
                arr = Enumerable.Range(1, 10000).Select(x => rand.Next(0, 1001));
                collection = new SortableCollection<int>(arr);
                elaps += watch.ElapsedMilliseconds;
                Console.WriteLine("Measured time: " + elaps + " ms.");
                watch.Reset();
                elaps = 0;
            }

            Console.WriteLine();
            Console.WriteLine("MergeSorter");
            for (int i = 0; i < 10; i++)
            {
                watch.Start();
                collection.Sort(new MergeSorter<int>());
                watch.Stop();
                arr = Enumerable.Range(1, 10000).Select(x => rand.Next(0, 1001));
                collection = new SortableCollection<int>(arr);
                elaps += watch.ElapsedMilliseconds;
                Console.WriteLine("Measured time: " + elaps + " ms.");
                watch.Reset();
                elaps = 0;
            }

            Console.WriteLine();
            Console.WriteLine("QuickSorter1");
            for (int i = 0; i < 10; i++)
            {
                elaps = 0;
                watch.Restart();
                collection.Sort(new QuickSorter<int>());
                watch.Stop();
                arr = Enumerable.Range(1, 10000).Select(x => rand.Next(0, 1001));
                collection = new SortableCollection<int>(arr);
                elaps += watch.ElapsedMilliseconds;
                Console.WriteLine("Measured time: " + elaps + " ms.");
                watch.Reset();
                elaps = 0;
            }

            Console.WriteLine();
            Console.WriteLine("QuickSorter2");
            for (int i = 0; i < 10; i++)
            {
                watch.Start();
                collection.Sort(new QuickTry<int>());
                watch.Stop();
                arr = Enumerable.Range(1, 10000).Select(x => rand.Next(0, 1001));
                collection = new SortableCollection<int>(arr);
                elaps += watch.ElapsedMilliseconds;
                Console.WriteLine("Measured time: " + elaps + " ms.");
                watch.Reset();
                elaps = 0;
            }
        }
    }
}
