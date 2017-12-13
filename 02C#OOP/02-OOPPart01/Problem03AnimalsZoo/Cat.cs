using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03AnimalsZoo
{
    public class Cat : Animal, ISound
    {
        private string typeFur;

        public Cat(int age, string name, AnimalSex sex, string typeFur)
            : base(age, name, sex)
        {
            this.typeFur = typeFur;
        }

        public string TypeFur
        {
            get { return this.typeFur; }
            set { this.typeFur = value; }
        }

        public override void Sound()
        {
            Console.WriteLine("Mau!");
        }

        public override string ToString()
        {
            return $"{base.ToString()}, TypeFur: {this.TypeFur}";
        }
    }
}
