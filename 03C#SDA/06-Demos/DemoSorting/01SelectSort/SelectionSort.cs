using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01SelectSort
{
    public class SelectionSort<T> where T : IComparable<T>
    {
        public static void Sort(T[] arr)
        {
            int min;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j].CompareTo(arr[min]) < 0)
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    Swap(i, min, arr);
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
