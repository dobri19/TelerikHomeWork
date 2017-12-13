using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03AnimalsZoo
{
    public class Dog : Animal, ISound
    {
        private string breed;

        public Dog(int age, string name, AnimalSex sex, string breed) 
            : base(age, name, sex)
        {
            this.Breed = breed;
        }

        public string Breed
        {
            get { return this.breed; }
            private set { this.breed = value; }
        }

        public override void Sound()
        {
            Console.WriteLine("BAU!");
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Breed: {this.Breed}";
        }
    }
}
