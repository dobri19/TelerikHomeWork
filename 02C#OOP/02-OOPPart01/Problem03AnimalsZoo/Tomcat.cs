using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03AnimalsZoo
{
    public class Tomcat : Cat, ISound
    {
        private const AnimalSex sexMale = AnimalSex.Male;

        public Tomcat(int age, string name, string typeFur) : base(age, name, sexMale, typeFur)
        {
        }

        public override void Sound()
        {
            Console.WriteLine("Hrrrrrr!");
        }

        public override string ToString()
        {
            return $"{base.ToString()}";
        }
    }
}
