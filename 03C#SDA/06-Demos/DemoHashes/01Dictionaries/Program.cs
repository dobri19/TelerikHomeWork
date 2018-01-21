using System;
using System.Collections;
using System.Collections.Generic;

namespace _01Dictionaries
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, City> collect = new Dictionary<string, City>();

            var city1 = new City("Sofia", 500000, 5, "Bulgaria");
            var city2 = new City("Varna", 500000, 5, "Bulgaria");
            var city3 = new City("Plovdiv", 200000, 2, "Kirzizstan");
            var city4 = new City("Stara Zagora", 10000, 4, "Bulgaria");
            var city5 = new City("Veliko Tyrnovo", 9000, 7, "Kirzizstan");

            collect.Add(city1.Name, city1);
            collect.Add(city2.Name, city2);
            collect.Add(city3.Name, city3);
            collect.Add(city4.Name, city4);
            collect.Add(city5.Name, city5);

            foreach (var item in collect)
            {
                Console.WriteLine(item.Value.ToString());
            }

            city1.Population = 300000;
            Console.WriteLine();

            foreach (var item in collect)
            {
                Console.WriteLine(item.Value.ToString());
                Console.WriteLine("hashcode: " + item.Value.GetHashCode());
            }

            Console.WriteLine(city1.Equals(city2));
            Console.WriteLine(city1.Equals(city3));
            Console.WriteLine(city1.Equals(city4));
        }
    }

    public class City
    {
        static Random random = new Random();

        string name;
        string country;
        int population;
        int temp;

        public City(string name, int population, int temp, string country)
        {
            this.name = name;
            this.population = population;
            this.temp = temp;
            this.country = country;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Population
        {
            get { return this.population; }
            set { this.population = value; }
        }

        public override string ToString()
        {
            string result;
            result = ($"name: {name}, population: {population}, temp: {temp}, country: {country}");
            return result;
        }

        public override int GetHashCode()
        {
            int zzz = random.Next(1, 4);
            return zzz;
        }

        public override bool Equals(object obj)
        {
            //return obj.ToString() == this.ToString();
            var sss = obj as City;
            return sss.country == this.country;
        }
    }
}
