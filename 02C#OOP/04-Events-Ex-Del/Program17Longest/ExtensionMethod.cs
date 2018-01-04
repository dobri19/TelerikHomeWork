using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program17Longest
{
    public static class ExtensionMethod
    {
        public static string MaxLenghtOfString(this List<string> collection)
        {
            string maxSting = collection.OrderByDescending(s => s.Length).First();

            return maxSting;
        }
    }
}
