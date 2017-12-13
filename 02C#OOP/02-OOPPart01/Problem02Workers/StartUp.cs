using System;
using System.Collections.Generic;

namespace Problem02Workers
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Student student = new Student("DJJJ", "Doncho", 7);
            Worker worker = new Worker("Sevdo", "Perdev", 1000M);
            Console.Write("Money per hour : ");
            Console.Write(worker.CalculateMoneyPerHour());
            Console.WriteLine("$");

            List<Human> humans = new List<Human>();

            humans.Add(worker);
            humans.Add(student);
            foreach (var human in humans)
            {
                human.RepresentSelf();
            }
        }
    }
}
