using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem02Workers
{
    public class Student : Human
    {
        private int grade;

        public int Grade
        {
            get { return grade; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The grade must be greater than 0");
                }
                grade = value;
            }
        }

        public Student(string firstName, string lastName)
            : base(firstName, lastName)
        {
        }

        public Student(string firstName, string lastName, int grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
        }
    }
}
