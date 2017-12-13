using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem02Workers
{
    public abstract class Human
    {
        private string firstName;
        private string lastName;

        public string FirstName
        {
            get { return this.firstName; }
            protected set
            {
                if (value.Length < 4)
                {
                    throw new ArgumentNullException("The name must be at least four characters long");
                }
                this.firstName = value;
            }
        }
        public string LastName
        {
            get { return this.lastName; }
            protected set
            {
                if (value.Length < 4)
                    throw new ArgumentNullException("The name must be at least four characters long");
                this.lastName = value;
            }
        }

        public virtual void RepresentSelf()
        {
            Console.WriteLine("Hello I am {0} {1}!", this.FirstName, this.LastName);
        }

        protected Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
