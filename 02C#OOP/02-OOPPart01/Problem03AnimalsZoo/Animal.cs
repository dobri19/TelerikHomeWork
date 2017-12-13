using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03AnimalsZoo
{
    public abstract class Animal : ISound
    {
        private int age;
        private string name;
        private AnimalSex sex;

        protected Animal(int age, string name, AnimalSex sex)
        {
            this.Age = age;
            this.Name = name;
            this.Sex = sex;
        }

        public int Age { get { return this.age; } set { this.age = value; } }
        public string Name { get { return this.name; } set { this.name = value; } }
        public AnimalSex Sex { get { return this.sex; } set { this.sex = value; } }

        public Type Type { get; protected set; }

        public abstract void Sound();

        public string GetAnimalType()
        {
            string type = this.GetType().BaseType.Name;
            if (type != "Animal")
            {
                return this.GetType().BaseType.Name;
            }
            else
            {
                return this.GetType().Name;
            }
        }

        public static string CalcAverageAge(IEnumerable<Animal> animalsList, Type type)
        {
            if (type == Type.Animal)
            {
                var averageAge = animalsList.Average(x => x.Age);
                return String.Format("The average age of the {0}s = {1} years old", type, Math.Round(averageAge, 2));
            }
            else
            {
                var averageAge = animalsList.Where(x => x.GetAnimalType() == type.ToString()).Average(x => x.Age);
                return String.Format("The average age of the {0}s = {1} years old", type, Math.Round(averageAge, 2));
            }
        }

        public override string ToString()
        {
            return $"{this.GetAnimalType()}: { this.Name}, Age: {this.Age}, Sex: {this.Sex}";
        }
    }
}
