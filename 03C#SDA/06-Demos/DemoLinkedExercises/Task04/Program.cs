using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task04
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            string exp = "1 + (2 - (2 + 3) * 4 / (3 + 1)) * 5";
            Stack<int> st = new Stack<int>();
            var result = new List<string>();
            int start = 0;
            for (int i = 0; i < exp.Length; i++)
            {
                if (exp[i] == '(')
                {
                    st.Push(i);
                }

                if (exp[i] == ')')
                {
                    start = st.Pop();
                    int end = i;

                    for (int j = start; j <= end; j++)
                    {
                        sb.Append(exp[j]);
                    }

                    result.Add(sb.ToString());
                    sb.Clear();
                }
            }

            Console.WriteLine(string.Join("|", result));
        }
    }
}
