using System;
using System.Collections.Generic;

namespace _03MultiDictionary
{
    public class Multi
    {
        static Dictionary<string, List<int>> studentGrades = new Dictionary<string, List<int>>();

        public static void Main(string[] args)
        {
            AddGrade("Pesho", 6);
            AddGrade("Pesho", 5);
            AddGrade("Maria", 3);
            AddGrade("Maria", 4);
            AddGrade("Pesho", 6);
            AddGrade("Maria", 3);
            AddGrade("Kiril", 4);

            PrintAllGrades();
        }

        private static void AddGrade(string name, int grade)
        {
            if (!studentGrades.ContainsKey(name))
            {
                studentGrades[name] = new List<int>();
            }
            studentGrades[name].Add(grade);
        }

        private static void PrintAllGrades()
        {
            foreach (var studentAndGrade in studentGrades)
            {
                Console.WriteLine(studentAndGrade.Key + ": ");
                foreach (var grade in studentAndGrade.Value)
                {
                    Console.WriteLine("\t" + grade);
                }
            }
        }
    }
}
