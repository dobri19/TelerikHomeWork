using System;
using System.Collections.Generic;
using System.Text;
using Wintellect.PowerCollections;

namespace _06V5Kiro
{
    public class Program
    {
        public static BigList<Player> playerRanking = new BigList<Player>();
        public static Dictionary<string, SortedSet<Player>> playerType = new Dictionary<string, SortedSet<Player>>();
        public static StringBuilder ForPrint = new StringBuilder();

        static void Main(string[] args)
        {
            string commParams;
            while ((commParams = Console.ReadLine()) != "end")
            {
                switch (commParams[0])
                {
                    case 'a':
                        AddPlayer(commParams);
                        break;
                    case 'f':
                        Find(commParams);
                        break;
                    case 'r':
                        Ranklist(commParams);
                        break;
                }
            }
            Console.WriteLine(ForPrint.ToString());
        }

        public static void AddPlayer(string comPars)
        {
            var commands = comPars.Split();

            string name = commands[1];
            string type = commands[2];
            int age = int.Parse(commands[3]);
            int pos = int.Parse(commands[4]);

            Player playerToBeAdded = new Player(name, type, age);
            playerRanking.Insert(pos - 1, playerToBeAdded);

            if (playerType.ContainsKey(type))
            {
                if (playerType[type].Count == 5)
                {
                    Player lastPlayer = playerType[type].Max;
                    if (lastPlayer.CompareTo(playerToBeAdded) > 0)
                    {
                        playerType[type].Remove(lastPlayer);
                        playerType[type].Add(playerToBeAdded);
                    }
                }
                else
                {
                    playerType[type].Add(playerToBeAdded);
                }
            }
            else
            {
                playerType[type] = new SortedSet<Player>();
                playerType[type].Add(playerToBeAdded);
            }

            ForPrint.AppendLine($"Added player {playerToBeAdded.Name} to position {pos}");
        }

        public static void Find(string comPars)
        {
            var commands = comPars.Split();

            string type = commands[1];

            if (playerType.ContainsKey(type))
            {
                ForPrint.Append($"Type {type}: ");
                foreach (Player player in playerType[type])
                {
                    ForPrint.Append($" {player};");
                }

                ForPrint.Remove(ForPrint.Length - 1, 1);
                ForPrint.AppendLine();
            }
            else
            {
                ForPrint.Append($"Type {type}: ");
                ForPrint.AppendLine();
            }
        }

        public static void Ranklist(string comPars)
        {
            var commands = comPars.Split();

            int startInd = int.Parse(commands[1]);
            int endInd = int.Parse(commands[2]);
            var askedRange = playerRanking.Range(startInd - 1, endInd - startInd + 1);
            int playerPosition = startInd;

            foreach (Player player in askedRange)
            {
                ForPrint.AppendFormat("{0}. {1}; ", playerPosition++, player);
            }

            ForPrint = ForPrint.Remove(ForPrint.Length - 2, 2);
            ForPrint = ForPrint.AppendLine();
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
            private set
            {
                this.name = value;
            }
        }
        public string Type
        {
            get { return this.type; }
            private set
            {
                this.type = value;
            }
        }
        public int Age
        {
            get { return this.age; }
            private set
            {
                this.age = value;
            }
        }
        public int CompareTo(Player other)
        {
            if (this.Name.CompareTo(other.Name) == 0)
            {
                return this.Age.CompareTo(other.Age) * -1;
            }

            return this.Name.CompareTo(other.Name);
        }
        public override string ToString()
        {
            return string.Format($"{this.Name}({this.Age})");
        }
    }
}

