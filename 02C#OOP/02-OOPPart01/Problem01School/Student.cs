using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem01School
{
    public class Student : Person, IComment
    {
        private int uniqueStudentNumber;

        public Student(string firstName, string lastName, int uniqueStudentNumber)
            : base(firstName, lastName)
        {
            this.UniqueStudentNumber = uniqueStudentNumber;
        }
        public Student(string firstName, string lastName, int uniqueStudentNumber, string comment)
            : this(firstName, lastName, uniqueStudentNumber)
        {
            this.Comment = comment;
        }

        public int UniqueStudentNumber { get => uniqueStudentNumber; set => uniqueStudentNumber = value; }

        public override string ToString()
        {

            if (this.Comment == "" || string.IsNullOrEmpty(this.Comment))
            {
                return this.FirstName + " " + this.LastName + ", Student Number -- " + this.UniqueStudentNumber;
            }
            else
            {
                return this.FirstName + " " + this.LastName + ", Student Number -- " + this.UniqueStudentNumber + ", (" + this.Comment+")";
            }
        }
    }
}
