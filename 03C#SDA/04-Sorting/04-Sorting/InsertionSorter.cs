using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingHomework
{
    public class InsertionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            var sorted = SortInsert(collection);

            for (int i = 0; i < collection.Count; i++)
            {
                collection[i] = sorted[i];
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
