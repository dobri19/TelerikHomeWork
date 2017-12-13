using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem01School
{
    public abstract class Person : IComment
    {
        private string comment;
        private string firstName;
        private string lastName;

        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string Comment
        {
            get { return this.comment; }
            set { this.comment = value; }
        }
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            protected set
            {
                this.firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            protected set
            {
                this.lastName = value;
            }
        }

        //public override string ToString()
        //{
        //    return this.FirstName + " " + this.LastName + "Comment :" + this.Comment;
        //}
    }
}
