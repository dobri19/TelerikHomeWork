namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            for (int i = 0; i < this.Items.Count; i++)
            {
                if (item.CompareTo(this.Items[i]) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            return SearchRecursive(this.Items, 0, this.Items.Count - 1, item);
        }

        private static bool SearchRecursive(IList<T> list, int from, int to, T element)
        {
            if (list == null || list.Count == 0)
            {
                return false;
            }

            if (from == to)
            {
                if (list[from].CompareTo(element) == 0)
                {
                    return true;
                }

                return false;
            }

            var mid = (from + to) / 2;

            if (list[mid].CompareTo(element) == 0)
            {
                return true;
            }

            if (list[mid].CompareTo(element) > 0)
            {
                return SearchRecursive(list, from, mid, element);
            }

            return SearchRecursive(list, mid + 1, to, element);
        }

        public void Shuffle()
        {
            //Random random = new Random();

            for (int i = 0; i < this.Items.Count - 1; i++)
            {
                int randomIndex = RandomProvider.Instance.Next(i + 1, this.Items.Count);
                Swap(this.Items, i, randomIndex);
            }
        }

        public static class RandomProvider
        {
            public static Random Instance = new Random();
        }

        private static void Swap(IList<T> list, int firstIndex, int secondIndex)
        {
            T swap = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = swap;
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
