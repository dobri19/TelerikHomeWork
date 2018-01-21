using System;
using System.Collections.Generic;
using System.Linq;

namespace V2Sashko
{
    public class Sashko
    {
        private static Dictionary<string, Unit> byName = new Dictionary<string, Unit>();
        private static Dictionary<string, ICollection<Unit>> byType = new Dictionary<string, ICollection<Unit>>();
        private static Dictionary<int, ICollection<Unit>> byPower = new Dictionary<int, ICollection<Unit>>();

        public static void Main(string[] args)
        {
            string command = Console.ReadLine();

            while (command != "end")
            {
                var commandArgs = command.Split();

                switch (commandArgs[0])
                {
                    case "add":
                        Add(commandArgs);
                        break;
                    case "remove":
                        Remove(commandArgs);
                        break;
                    case "find":
                        Find(commandArgs);
                        break;
                    case "power":
                        Console.WriteLine(Power(commandArgs));
                        break;
                }

                command = Console.ReadLine();
            }
        }

        private static void Add(string[] commandArgs)
        {
            var name = commandArgs[1];
            var type = commandArgs[2];
            var attack = int.Parse(commandArgs[3]);

            if (!byName.ContainsKey(name))
            {
                var unit = new Unit(name, type, attack);

                byName.Add(name, unit);

                if (!byType.ContainsKey(type))
                {
                    byType.Add(type, new List<Unit>());
                }

                byType[type].Add(unit);

                if (!byPower.ContainsKey(attack))
                {
                    byPower.Add(attack, new List<Unit>());
                }

                byPower[attack].Add(unit);

                Console.WriteLine($"SUCCESS: {name} added!");
            }
            else
            {
                Console.WriteLine($"FAIL: {name} already exists!");
            }
        }

        private static void Remove(string[] commandArgs)
        {
            var name = commandArgs[1];

            if (byName.ContainsKey(name))
            {
                var unit = byName[name];

                byName.Remove(name);
                byPower[unit.Attack].Remove(unit);
                byType[unit.Type].Remove(unit);

                Console.WriteLine($"SUCCESS: {name} removed!");
            }
            else
            {
                Console.WriteLine($"FAIL: {name} could not be found!");
            }
        }

        private static void Find(string[] commandArgs)
        {
            var type = commandArgs[1];

            if (!byType.ContainsKey(type))
            {
                Console.WriteLine($"RESULT: ");
                return;
            }

            var result = byType[type].OrderByDescending(x => x.Attack)
                                     .ThenBy(x => x.Name)
                                     .Take(10)
                                     .ToList();

            Console.WriteLine($"RESULT: {string.Join(", ", result)}");
        }

        private static string Power(string[] commandArgs)
        {
            var count = int.Parse(commandArgs[1]);

            var counter = 0;
            var result = new List<Unit>();
            var keys = byPower.Keys.OrderByDescending(x => x).ToList();

            foreach (var k in keys)
            {
                var next = byPower[k].OrderBy(x => x.Name).ToList();

                foreach (var item in next)
                {
                    result.Add(item);
                    counter++;

                    if (counter >= count)
                    {
                        return "RESULT: " + string.Join(", ", result);
                    }
                }
            }
            return "RESULT: " + string.Join(", ", result);
        }
    }
    public class Unit : IComparable<Unit>
    {
        public Unit(string name, string type, int attack)
        {
            this.Name = name;
            this.Type = type;
            this.Attack = attack;
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Attack { get; set; }

        public int CompareTo(Unit other)
        {
            var result = other.Attack.CompareTo(this.Attack);
            if (result == 0)
            {
                result = this.Name.CompareTo(other.Name);
            }
            return result;
        }

        public override string ToString()
        {
            return $"{this.Name}[{this.Type}]({this.Attack})";
        }
    }
}