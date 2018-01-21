using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01SelectSort
{
    public class QuickSort<T> where T : IComparable<T>
    {
        public static List<int> QuickSortDobri(List<int> numbers, bool isOptimized = false)
        {
            //// stable variant
            if (numbers == null || numbers.Count <= 1)
            {
                return numbers;
            }

            // call insertion sort when elements reach below 30 (about 20 % better times)
            if (isOptimized && numbers.Count <= 20)
            {
               InsertionMethods<int>.Sort(numbers.ToArray());
            }

            int pivotIndex = numbers.Count / 2;
            //int pivot = numbers[pivotIndex];

            int firstElement = numbers[0];
            int middleElement = numbers[pivotIndex];
            int lastElement = numbers[numbers.Count - 1];

            int pivot = GetAverageValue(firstElement, middleElement, lastElement);

            List<int> result = new List<int>();
            List<int> left = new List<int>();
            List<int> right = new List<int>();

            for (int i = 0; i < pivotIndex; i++)
            {
                if (numbers[i] <= pivot)
                {
                    left.Add(numbers[i]);
                }
                else
                {
                    right.Add(numbers[i]);
                }
            }

            for (int i = pivotIndex + 1; i < numbers.Count; i++)
            {
                if (numbers[i] < pivot)
                {
                    left.Add(numbers[i]);
                }
                else
                {
                    right.Add(numbers[i]);
                }
            }

            //if (isAsync)
            //{
            //    Task leftTask = Task.Run(() => QuickSortDobri(left, isOptimized));
            //    Task rightTask = Task.Run(() => QuickSortDobri(right, isOptimized));
            //    //Task.WaitAll(leftTask, rightTask);
            //}
            //else
            //{
                left = QuickSortDobri(left, isOptimized);
                right = QuickSortDobri(right, isOptimized);
            //}

            result.AddRange(left);
            result.Add(pivot);
            result.AddRange(right);

            return result;
        }

        public static int GetAverageValue(int firstElement, int secondElement, int thirdElement)
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
    }
}
