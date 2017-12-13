using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03AnimalsZoo
{
    public class Frog : Animal, ISound
    {
        private int numberDots;

        public Frog(int age, string name, AnimalSex sex, int numberDots)
            : base(age, name, sex)
        {
            this.NumberDots = numberDots;
        }

        public int NumberDots
        {
            get { return this.numberDots; }
            set { this.numberDots = value; }
        }

        public override void Sound()
        {
            Console.WriteLine("Kriak!");
        }

        public override string ToString()
        {
            return $"{base.ToString()}, NumberDots: {this.NumberDots}";
        }
    }
}
