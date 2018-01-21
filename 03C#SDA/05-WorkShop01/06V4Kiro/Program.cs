using System;
using System.Collections.Generic;
using System.Text;
using Wintellect.PowerCollections;

namespace _06V4Kiro
{
    public class Program
    {
        public static BigList<Player> players = new BigList<Player>();
        public static Dictionary<string, OrderedBag<Player>> ranking = new Dictionary<string, OrderedBag<Player>>();
        public static StringBuilder result = new StringBuilder();

        static void Main(string[] args)
        {
            string command = "";
            while ((command = Console.ReadLine().Trim()) != "end")
            {
                string[] commParams = command.Split();
                switch (commParams[0])
                {
                    case "add":
                        AddPlayer(commParams);
                        break;
                    case "find":
                        Find(commParams);
                        break;
                    case "ranklist":
                        Ranklist(commParams);
                        break;
                }
            }
            Console.WriteLine(result.ToString().Trim());
        }

        public static void AddPlayer(string[] comPars)
        {
            string name = comPars[1];
            string type = comPars[2];
            int age = int.Parse(comPars[3]);
            int pos = int.Parse(comPars[4]);

            var playerToBeAdded = new Player(name, type, age);
            players.Insert(pos - 1, playerToBeAdded);

            if (ranking.ContainsKey(type))
            {
                if (ranking[type].Count == 5)
                {
                    Player lastPlayer = ranking[type][4];
                    if (lastPlayer.CompareTo(playerToBeAdded) > 0)
                    {
                        ranking[type].Remove(lastPlayer);
                        ranking[type].Add(playerToBeAdded);
                    }
                }
                else
                {
                    ranking[type].Add(playerToBeAdded);
                }
            }
            else
            {
                ranking[type] = new OrderedBag<Player>();
                ranking[type].Add(playerToBeAdded);
            }

            result.AppendLine($"Added player {playerToBeAdded.Name} to position {pos}");
        }

        public static void Find(string[] comPars)
        {
            string type = comPars[1];

            if (players.Count == 0)
            {
                result.AppendLine($"Type {type}: ");
                return;
            }
            result.AppendFormat($"Type {type}: ");

            if (ranking.ContainsKey(type))
            {
                var currTypePlayersList = ranking[comPars[1]];
                var list = new List<string>();
                foreach (var player in currTypePlayersList)
                {
                    list.Add($"{player.ToString()}");
                }
                result.AppendLine(string.Join("; ", list));
            }
            else
            {
                result.AppendLine();
            }
        }

        public static void Ranklist(string[] comPars)
        {
            int startInd = int.Parse(comPars[1]) - 1;
            int endInd = int.Parse(comPars[2]) - 1;
            int range = endInd - startInd + 1;
            var askedRange = players.Range(startInd, range);
            int playerPosition = startInd + 1;

            foreach (Player player in askedRange)
            {
                result.AppendFormat("{0}. {1}; ", playerPosition++, player);
            }

            result = result.Remove(result.Length - 2, 2);
            result = result.AppendLine();
        }
    }

    public class Player : IComparable<Player>
    {
        private string name;
        private string type;
        private int age;

        public Player(string name, string type, int age)
        {
            this.Name = name;
            this.Type = type;
            this.Age = age;
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public string Type
        {
            get { return this.type; }
            private set { this.type = value; }
        }

        public int Age
        {
            get { return this.age; }
            private set { this.age = value; }
        }

        public int CompareTo(Player other)
        {
            int output;
            return output = this.Name.CompareTo(other.Name) != 0
                         ? this.Name.CompareTo(other.Name)
                         : this.Age.CompareTo(other.Age) * -1;
        }

        public override string ToString()
        {
            string line = string.Format($"{this.Name}({this.Age})");
            return line;
        }
    }
}

