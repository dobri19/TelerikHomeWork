using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03AnimalsZoo
{
    public class Kitten : Cat, ISound
    {
        private const AnimalSex sexFemale = AnimalSex.Female;

        public Kitten(int age, string name, string typeFur) : base(age, name, sexFemale, typeFur)
        {
        }

        public override void Sound()
        {
            Console.WriteLine("Macccccy!");
        }

        public override string ToString()
        {
            return $"{base.ToString()}";
        }
    }
}
