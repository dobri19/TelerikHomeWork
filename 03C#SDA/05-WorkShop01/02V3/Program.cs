﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _02V3
{
    public class Program
    {
        static Dictionary<char, string> ciphers = new Dictionary<char, string>();
        static string message;

        public static void Main(string[] args)
        {
            message = Console.ReadLine();
            string cipher = Console.ReadLine();
            //message = "1122";
            //string cipher = "A1B12C11D2";

            char key = char.MinValue;
            StringBuilder value = new StringBuilder();

            for (int i = 0; i < cipher.Length; i++)
            {
                if (cipher[i] >= 'A' && cipher[i] <= 'Z')
                {
                    if (key != char.MinValue)
                    {
                        ciphers.Add(key, value.ToString());
                        value.Clear();
                    }

                    key = cipher[i];
                }
                else
                {
                    value.Append(cipher[i]);
                }
            }

            if (key != char.MinValue)
            {
                ciphers.Add(key, value.ToString());
                value.Clear();
            }

            Solve(0, new StringBuilder());

            Console.WriteLine(solutions.Count);
            solutions.Sort();
            foreach (var item in solutions)
            {
                Console.WriteLine(item);
            }
        }

        static List<string> solutions = new List<string>();

        static void Solve(int messageIndex, StringBuilder sb)
        {
            if (messageIndex == message.Length)
            {
                solutions.Add(sb.ToString());
                return;
            }

            foreach (var cipher in ciphers)
            {
                if (message.Substring(messageIndex).StartsWith(cipher.Value))
                {
                    sb.Append(cipher.Key);
                    Solve(messageIndex + cipher.Value.Length, sb);
                    sb.Length--;
                }
            }
        }
    }
}
