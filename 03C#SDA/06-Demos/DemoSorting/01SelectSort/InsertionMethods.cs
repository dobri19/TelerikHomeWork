using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01SelectSort
{
    public class InsertionMethods<T> where T : IComparable<T>
    {
        public static void Sort(T[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int j = i;


                //while ((j > 0) && (arr[j].CompareTo(arr[j - 1]) < 0))
                //{
                //    Swap(j, j - 1, arr);
                //    j--;
                //}

                //optimization
                T temp = arr[j];
                while ((j > 0) && (arr[j - 1].CompareTo(temp) > 0))
                {
                    arr[j] = arr[j - 1];
                    j--;
                }

                arr[j] = temp;
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
