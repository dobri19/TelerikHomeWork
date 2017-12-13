using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03AnimalsZoo
{
    public class TestAnimalsZoo
    {
        private static List<Animal> CreateZoo()
        {
            List<Animal> jivotni = new List<Animal>();

            Animal bau = new Dog(23, "Sashko", AnimalSex.Male, "Doggy");
            Animal mau = new Cat(4, "Maca", AnimalSex.Female, "Roshava");
            Animal kermit = new Frog(7, "Kermitcho", AnimalSex.Male, 666);
            Animal kitty = new Kitten(2, "Pisana", "Angorska");
            Animal tom = new Tomcat(5, "Jerry", "Polska");
            Animal bau2 = new Dog(23, "Sashko", AnimalSex.Male, "Doggy");
            Animal mau2 = new Cat(4, "Maca", AnimalSex.Female, "Roshava");
            Animal kermit2 = new Frog(7, "Kermitcho", AnimalSex.Male, 666);
            Animal kitty2 = new Kitten(2, "Pisana", "Angorska");
            Animal tom2 = new Tomcat(5, "Jerry", "Polska");

            jivotni.Add(bau);
            jivotni.Add(mau);
            jivotni.Add(kermit);
            jivotni.Add(kitty);
            jivotni.Add(tom);
            jivotni.Add(bau2);
            jivotni.Add(mau2);
            jivotni.Add(kermit2);
            jivotni.Add(kitty2);
            jivotni.Add(tom2);

            return jivotni;
        }

        public static void PrintZoo()
        {
            foreach (var item in CreateZoo())
            {
                Console.WriteLine(item);
                item.Sound();
            }
        }

        public static void PrintAges()
        {
            Console.WriteLine(Animal.CalcAverageAge(CreateZoo(), Type.Animal));
            Console.WriteLine(Animal.CalcAverageAge(CreateZoo(), Type.Cat));
            Console.WriteLine(Animal.CalcAverageAge(CreateZoo(), Type.Dog));
            Console.WriteLine(Animal.CalcAverageAge(CreateZoo(), Type.Frog));
            //Console.WriteLine(Animal.CalcAverageAge(CreateZoo(), Type.Kitten));
            //Console.WriteLine(Animal.CalcAverageAge(CreateZoo(), Type.Tomcat));
        }
    }
}
