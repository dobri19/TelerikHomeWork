using System;
using System.Collections.Generic;
using System.Text;
using Wintellect.PowerCollections;

namespace _06V3Mine
{
    public class StartUp
    {
        static BigList<Player> players = new BigList<Player>();
        static Dictionary<string, SortedSet<Player>> ranking = new Dictionary<string, SortedSet<Player>>();
        static StringBuilder result = new StringBuilder();

        public static void Main(string[] args)
        {
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                switch (command[0])
                {
                    case 'a':
                        Add(command);
                        break;
                    case 'f':
                        Find(command);
                        break;
                    case 'r':
                        Rank(command);
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(result.ToString());
        }

        private static void Add(string command)
        {
            var commands = command.Split();

            string name = commands[1];
            string type = commands[2];
            int age = int.Parse(commands[3]);
            int position = int.Parse(commands[4]);

            Player player = new Player(name, type, age, position);

            if (ranking.ContainsKey(type))
            {
                if (ranking[type].Count == 5)
                {
                    Player lastPlayer = ranking[type].Max;
                    if (lastPlayer.CompareTo(player) > 0)
                    {
                        ranking[type].Remove(lastPlayer);
                        ranking[type].Add(player);
                    }
                }
                else
                {
                    ranking[type].Add(player);
                }
            }
            else
            {
                ranking[type] = new SortedSet<Player>();
                ranking[type].Add(player);
            }

            players.Insert(position - 1, player);
            result.AppendLine($"Added player {name} to position {position}");
        }

        private static void Rank(string command)
        {
            var commands = command.Split();

            int start = int.Parse(commands[1]);
            int end = int.Parse(commands[2]);

            var rankings1 = players.GetRange(start - 1, end - start + 1);
            int playerPosition = start;

            foreach (Player player in rankings1)
            {
                result.AppendFormat("{0}. {1}; ", playerPosition++, player);
            }

            result = result.Remove(result.Length - 2, 2);
            result = result.AppendLine();
        }

        private static void Find(string command)
        {
            var commands = command.Split();
            string type = commands[1];

            if (ranking.ContainsKey(type))
            {
                result.Append($"Type {type}:");
                foreach (Player item in ranking[type])
                {
                    result.Append($" {item};");
                }

                result.Remove(result.Length - 1, 1);
                result.AppendLine();
            }
            else
            {
                result.Append($"Type {type}: ");
                result.AppendLine();
            }
        }
    }

    public class Player : IComparable<Player>
    {
        string Name { get; set; }
        string Type { get; set; }
        int Age { get; set; }
        int Position { get; set; }

        public Player(string name, string type, int age, int position)
        {
            this.Name = name;
            this.Type = type;
            this.Age = age;
            this.Position = position;
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Age);
        }

        public int CompareTo(Player obj)
        {
            if (this.Name.CompareTo(obj.Name) == 0)
            {
                return this.Age.CompareTo(obj.Age) * -1;
            }

            return this.Name.CompareTo(obj.Name);
        }
    }
}
