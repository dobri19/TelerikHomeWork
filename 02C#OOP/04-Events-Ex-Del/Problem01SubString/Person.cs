using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem01SubString
{
    public class Person : IComparable<Person>
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public Person(int age, string name)
        {
            this.Age = age;
            this.Name = name;
        }

        public int CompareTo(Person obj)
        {
            return (Age - obj.Age);
        }

        public override string ToString()
        {
            return (this.Age +" "+ this.Name);
        }
    }
}
