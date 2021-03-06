﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace PlayersRanking
{
    public class Players
    {
        private static readonly Dictionary<string, ICollection<Player>> playersByType = new Dictionary<string, ICollection<Player>>();
        private static readonly BigList<Player> players = new BigList<Player>();

        private const string SuccessAdd = "Added player {0} to position {1}";
        private const string Result = "Type {0}: {1}";

        public static void Main(string[] args)
        {
            // ReadInput();
            var command = Console.ReadLine();
            while (command != "end")
            {
                var splittedCommand = command.Split(' ');

                var commandType = splittedCommand[0];

                if (commandType == "add")
                {
                    Add(splittedCommand);
                }
                else if (commandType == "ranklist")
                {
                    Ranklist(splittedCommand);
                }
                else if (commandType == "find")
                {
                    Find(splittedCommand);
                }
                command = Console.ReadLine();
            }
        }

        private static void Ranklist(string[] splittedCommand)
        {
            var min = int.Parse(splittedCommand[1]);
            var max = int.Parse(splittedCommand[2]);

            var builder = new StringBuilder();

            for (var i = min - 1; i < max - 1; i++)
            {
                builder.Append(string.Format("{0}. {1}; ", i + 1, players[i]));
            }
            builder.Append(string.Format("{0}. {1}", max, players[max - 1]));

            Console.WriteLine(builder);
        }

        private static void Find(string[] splittedCommand)
        {
            var type = splittedCommand[1];

            var productsType = Enumerable.Empty<Player>();

            if (playersByType.ContainsKey(type))
            {
                productsType = playersByType[type]
                   .Take(5).OrderBy(x => x.Name).ThenBy(x => -x.Age).ToList();
            }

            Console.WriteLine(Result, type, string.Join("; ", productsType));
        }

        private static void Add(string[] parameters)
        {
            var unitName = parameters[1];

            var unitType = parameters[2];
            var age = int.Parse(parameters[3]);
            var position = int.Parse(parameters[4]);

            var unit = new Player
            {
                Name = unitName,
                Age = age,
                Type = unitType,
                Position = position
            };

            if (playersByType.ContainsKey(unitType))
            {
                playersByType[unitType].Add(unit);
            }
            else
            {
                playersByType[unitType] = new OrderedSet<Player> { unit };
            }

            if (position > players.Count)
            {
                players.Add(unit);
            }
            else
            {
                players.Insert(position - 1, unit);
            }

            Console.WriteLine(SuccessAdd, unitName, position);
        }
    }

    public class Player : IComparable<Player>
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public int Age { get; set; }

        public int Position { get; set; }

        public int CompareTo(Player other)
        {
            var result = this.Name.CompareTo(other.Name);

            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age) * -1;
            }

            return result;
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Age);
        }
    }
}
