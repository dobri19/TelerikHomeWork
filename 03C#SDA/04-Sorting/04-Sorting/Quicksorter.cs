namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class QuickSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            Sort(collection, 0, collection.Count - 1);
        }

        private void Sort(IList<T> collection, int low, int high)
        {
            //if (collection.Count <= 20)
            //{
            //    SortInsert(collection);
            //}

            if (low < high)
            {
                var p = Partition(collection, low, high);

                //Task leftTask = Task.Run(() => Sort(collection, low, p - 1));
                //Task rightTask = Task.Run(() => Sort(collection, p + 1, high));
                Sort(collection, low, p - 1);
                Sort(collection, p + 1, high);
            }
        }

        private int Partition(IList<T> collection, int low, int high)
        {
            //var pivotIndex = collection.Count / 2;

            //var firstElement = collection[0];
            //var middleElement = collection[pivotIndex];
            //var lastElement = collection[collection.Count - 1];

            //T pivot = GetAverageValue(firstElement, middleElement, lastElement);

            var pivot = collection[low];

            var pivotIndex = high;

            for (int i = pivotIndex; i > low; i--)
            {
                if (collection[i].CompareTo(pivot) > 0)
                {
                    Swap(i, pivotIndex, collection);
                    pivotIndex--;
                }
            }

            Swap(pivotIndex, low, collection);
            return pivotIndex;
        }

        private static void Swap(int i, int j, IList<T> collection)
        {
            var temp = collection[j];
            collection[j] = collection[i];
            collection[i] = temp;
        }

        private static T GetAverageValue(T firstElement, T secondElement, T thirdElement)
        {
            if (firstElement.CompareTo(secondElement) > 0)
            {
                if (secondElement.CompareTo(thirdElement) > 0)
                {
                    return secondElement;
                }
                else if (firstElement.CompareTo(thirdElement) > 0)
                {
                    return thirdElement;
                }
                else
                {
                    return firstElement;
                }
            }
            else
            {
                if (firstElement.CompareTo(thirdElement) > 0)
                {
                    return firstElement;
                }
                else if (secondElement.CompareTo(thirdElement) > 0)
                {
                    return thirdElement;
                }
                else
                {
                    return secondElement;
                }
            }
        }

        public IList<T> SortInsert(IList<T> collection)
        {
            int n = collection.Count;
            for (int i = 1; i < n; i++)
            {
                int j = i;
                while ((j > 0) && (collection[j].CompareTo(collection[j - 1]) < 0))
                {
                    var swap = collection[j - 1];
                    collection[j - 1] = collection[j];
                    collection[j] = swap;
                    j--;
                }
            }

            return collection;
        }
    }
}
