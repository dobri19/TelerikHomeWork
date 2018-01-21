using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01SelectSort
{
    public class BubbleSort<T> where T : IComparable<T>
    {
        public static void Sort(T[] arr)
        {
            bool notSorted = true;
            while (notSorted)
            {
                notSorted = false;
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j].CompareTo(arr[j + 1]) > 0)
                    {
                        Swap(j, j + 1, arr);
                        notSorted = true;
                    }
                }
            }
        }

        private static void Swap(int i, int j, T[] arr)
        {
            var temp = arr[j];
            arr[j] = arr[i];
            arr[i] = temp;
        }
    }
}
