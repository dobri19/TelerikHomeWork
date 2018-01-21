using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07V3Mine
{
    public class Program
    {
        static Dictionary<string, SortedSet<Unit>> unitsType = new Dictionary<string, SortedSet<Unit>>();
        static Dictionary<string, Unit> unitsName = new Dictionary<string, Unit>();
        static SortedSet<Unit> unitsAttack = new SortedSet<Unit>();
        static StringBuilder result = new StringBuilder();

        public static void Main(string[] args)
        {
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandInput = command.Split();
                switch (commandInput[0])
                {
                    case "add":
                        Add(commandInput);
                        break;
                    case "find":
                        Find(commandInput);
                        break;
                    case "power":
                        Power(commandInput);
                        break;
                    case "remove":
                        Remove(commandInput);
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(result.ToString());
        }

        private static void Add(string[] commandInput)
        {
            //var commands = command.Split();

            string name = commandInput[1];
            string type = commandInput[2];
            int attack = int.Parse(commandInput[3]);

            Unit unit = new Unit(name, type, attack);

            if (unitsName.ContainsKey(name))
            {
                result.AppendLine(string.Format("FAIL: {0} already exists!", name));
            }
            else
            {
                unitsName.Add(name, unit);
                unitsAttack.Add(unit);
                if (!unitsType.ContainsKey(type))
                {
                    unitsType.Add(type, new SortedSet<Unit>());
                }

                unitsType[type].Add(unit);

                result.AppendLine(string.Format("SUCCESS: {0} added!", name));
            }
        }

        private static void Find(string[] commandInput)
        {
            //var commands = command.Split();

            string type = commandInput[1];

            if (unitsType.ContainsKey(type))
            {
                result.AppendLine(string.Format("RESULT: {0}", string.Join(", ", unitsType[type].Take(10))));
            }
            else
            {
                result.AppendLine("RESULT: ");
            }
        }

        private static void Power(string[] commandInput)
        {
            //var commands = command.Split();

            int count = int.Parse(commandInput[1]);

            result.AppendLine(string.Format("RESULT: {0}", string.Join(", ", unitsAttack.Take(count))));
        }

        private static void Remove(string[] commandInput)
        {
            //var commands = command.Split();

            string name = commandInput[1];

            if (unitsName.ContainsKey(name))
            {
                Unit unit = unitsName[name];

                unitsName.Remove(name);
                unitsAttack.Remove(unit);
                unitsType[unit.Type].Remove(unit);

                result.AppendLine(string.Format("SUCCESS: {0} removed!", name));
            }
            else
            {
                result.AppendLine(string.Format("FAIL: {0} could not be found!", name));
            }
        }
    }

    public class Unit : IComparable<Unit>
    {
        string Name { get; set; }
        public string Type { get; set; }
        int Attack { get; set; }

        public Unit(string name, string type, int attack)
        {
            this.Name = name;
            this.Type = type;
            this.Attack = attack;
        }

        public override string ToString()
        {
            return string.Format("{0}[{1}]({2})", this.Name, this.Type, this.Attack);
        }

        public int CompareTo(Unit obj)
        {
            if (this.Attack.CompareTo(obj.Attack) == 0)
            {
                return this.Name.CompareTo(obj.Name);
            }

            return this.Attack.CompareTo(obj.Attack) * -1;
        }
    }
}
