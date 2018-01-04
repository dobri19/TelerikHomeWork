using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem01SubString
{
    public static class Utils
    {
        public static StringBuilder SubstringEx(this StringBuilder sb, int index, int length)
        {
            StringBuilder sbuild = new StringBuilder();

            for (int i = index; i < index + length; i++)
            {
                sbuild.Append(sb[i]);
            }
            return sbuild;
        }

        public static T SumEx<T>(this IEnumerable<T> collection)
        {
            T sum = default(T);
            if (collection.Count() == 0)
            {
                throw new ArgumentOutOfRangeException("The collection is empty!");
            }
            else
            {
                foreach (var item in collection)
                {
                    sum = sum + (dynamic)item;
                }
            }
            return sum;
        }

        public static T MinEx<T>(this IEnumerable<T> collection)
        {
            if (collection.Count() == 0)
            {
                throw new ArgumentOutOfRangeException("The collection is empty!");
            }
            else
            {
                return collection.OrderBy(x => x).First();
            }
        }

        public static T MaxEx<T>(this IEnumerable<T> collection)
        {
            if (collection.Count() == 0)
            {
                throw new ArgumentOutOfRangeException("The collection is empty!");
            }
            else
            {
                return collection.OrderByDescending(x => x).First();
                //dynamic max = long.MinValue;
                //foreach (T item in collection)
                //{
                //    if (item > max)
                //        max = item;
                //}
                //return max;
            }
        }

        public static T AverageEx<T>(this IEnumerable<T> collection)
        {
            if (collection.Count() == 0)
            {
                throw new ArgumentOutOfRangeException("The collection is empty!");
            }
            T sum = default(T);
            T average = default(T);

            foreach (var item in collection)
            {
                sum += (dynamic)item;
            }
            return average = (dynamic)sum / collection.Count();
        }

        public static int CountEx<T>(this IEnumerable<T> collection)
        {
            int count = 0;

            foreach (T item in collection)
            {
                count++;
            }
            return count;
        }

        public static T ProductEx<T>(this IEnumerable<T> collection)
        {
            dynamic sum = 1;

            foreach (T item in collection)
            {
                sum *= item;
            }

            return sum;
        }

        public static string ToStringEx<T>(this IEnumerable<T> collection)
        {
            return String.Join(", ", collection);
        }
    }
}
