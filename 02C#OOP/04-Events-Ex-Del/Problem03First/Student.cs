using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem03First
{
    public class Student
    {
        public Student(int age, string firstName, string lastName)
        {
            this.Age = age;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public int Age { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public override string ToString()
        {
            return (this.Age + " " + this.FirstName + " " + this.LastName);
        }
    }
}
