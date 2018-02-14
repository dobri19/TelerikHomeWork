using System.Collections.Generic;
using System.Linq;
using System.Text;
using OlympicGames.Core.Commands.Abstracts;
using OlympicGames.Core.Contracts;
using OlympicGames.Utils;

namespace OlympicGames.Core.Commands
{
    public class ListOlympiansCommand : Command, ICommand
    {
        private string key;
        private string order;

        public ListOlympiansCommand(IOlympicCommittee committee, IOlympicsFactory factory)
            : base(committee, factory)
        {
        }

        public override string Execute(IList<string> commandParameters)
        {
            if (commandParameters == null || commandParameters.Count == 1)
            {
                this.key = "firstname";
                this.order = "asc";
            }
            else if (commandParameters.Count == 2)
            {
                this.key = commandParameters[1];
                this.order = "asc";
            }
            else
            {
                if (commandParameters[2].ToLower() != "asc" && commandParameters[2].ToLower() != "desc")
                {
                    this.order = "asc";
                }
                else
                {
                    this.order = commandParameters[2];
                }
                this.key = commandParameters[1];
            }

            var stringBuilder = new StringBuilder();
            var sorted = this.Committee.Olympians.ToList();

            if (sorted.Count == 0)
            {
                stringBuilder.AppendLine(GlobalConstants.NoOlympiansAdded);
                return stringBuilder.ToString();
            }

            stringBuilder.AppendLine(string.Format(GlobalConstants.SortingTitle, this.key, this.order));

            if (this.order.ToLower().Trim() == "desc")
            {
                sorted = this.Committee.Olympians.OrderByDescending(x =>
                {
                    return x.GetType().GetProperties().FirstOrDefault(y => y.Name.ToLower() == this.key.ToLower()).GetValue(x, null);
                }).ToList();
            }
            else
            {
                sorted = this.Committee.Olympians.OrderBy(x =>
                {
                    return x.GetType().GetProperties().FirstOrDefault(y => y.Name.ToLower() == this.key.ToLower()).GetValue(x, null);
                }).ToList();
            }

            foreach (var item in sorted)
            {
                stringBuilder.AppendLine(item.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}
