using SortingHomework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingHomework
{
    public class QuickTry<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            //Sort(collection, 0, collection.Count - 1);
            var sorted = SortQuick(collection);

            for (int i = 0; i < collection.Count; i++)
            {
                collection[i] = sorted[i];
            }
        }

        private IList<T> SortQuick(IList<T> collection)
        {
            if (collection == null || collection.Count <= 1)
            {
                return collection;
            }

            //if (collection.Count <= 30)
            //{
            //    return SortInsert(collection);
            //}

            var pivotIndex = collection.Count / 2;
            //int pivot = numbers[pivotIndex];

            var firstElement = collection[0];
            var middleElement = collection[pivotIndex];
            var lastElement = collection[collection.Count - 1];

            var pivot = GetAverageValue(firstElement, middleElement, lastElement);

            IList<T> result = new List<T>();
            IList<T> left = new List<T>();
            IList<T> right = new List<T>();

            for (int i = 0; i < pivotIndex; i++)
            {
                if (collection[i].CompareTo(pivot) <= 0)
                {
                    left.Add(collection[i]);
                }
                else
                {
                    right.Add(collection[i]);
                }
            }

            for (int i = pivotIndex + 1; i < collection.Count; i++)
            {
                if (collection[i].CompareTo(pivot) < 0)
                {
                    left.Add(collection[i]);
                }
                else
                {
                    right.Add(collection[i]);
                }
            }

            Task leftTask = Task.Run(() => SortQuick(left));
            Task rightTask = Task.Run(() => SortQuick(right));
            //left = SortQuick(left);
            //right = SortQuick(right);

            result = AddMine(result, left);
            result.Add(pivot);
            result = AddMine(result, right);

            return result;
        }

        private static IList<T> AddMine(IList<T> left, IList<T> right)
        {
            for (int i = 0; i < right.Count; i++)
            {
                left.Add(right[i]);
            }

            return left;
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
