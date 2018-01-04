using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem03First
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
               new Student(34, "Petko", "Gorkov"),
               new Student(18, "Stafcho", "Patlov"),
               new Student(22, "Jechko", "Alabamov"),
               new Student(44, "Android", "Susamov")
            };

            //// Problem03
            //// Linq query
            //var linqQ =
            //           from student in students
            //           where student.FirstName.CompareTo(student.LastName) < 0
            //           select student;

            //// Exmethod
            //var exMethod = students.Where(student => student.FirstName.CompareTo(student.LastName) < 0);

            //Console.WriteLine("1: Using LINQ query: ");
            //Console.WriteLine(string.Join(Environment.NewLine, linqQ));

            //Console.WriteLine("\n2: Using Exmethod: ");
            //Console.WriteLine(string.Join(Environment.NewLine, exMethod));

            //// Problem04
            //var sortedStudents = students
            //   .Where(x => (x.Age >= 18) && (x.Age <= 24))
            //   .Select(x => new
            //   {
            //       FirstName = x.FirstName,
            //       LastName = x.LastName
            //   });

            //Console.WriteLine(string.Join(", ", sortedStudents));

            // Problem05
            // Linq query
            var orderedStudents =
                from student in students
                orderby student.FirstName descending, student.LastName descending
                select student;

            Console.WriteLine("1: Using LINQ: ");
            Console.WriteLine(string.Join(Environment.NewLine, orderedStudents));

            // Extension methods
            var ordStudents = students.OrderByDescending(x => x.FirstName).ThenBy(y => y.LastName);

            Console.WriteLine("2: Using extension methods: ");
            Console.WriteLine(string.Join(Environment.NewLine, ordStudents));
        }
    }
}
