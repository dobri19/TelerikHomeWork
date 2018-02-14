using OlympicGames.Core.Contracts;
using OlympicGames.Olympics.Contracts;
using System.Collections.Generic;

namespace OlympicGames.Core.Commands
{
    public class CreateSprinterCommand : CreateOlympianCommand, ICommand
    {
        private readonly IDictionary<string, double> records;

        public CreateSprinterCommand(IOlympicCommittee committee, IOlympicsFactory factory, IList<string> commandParameters)
            : base(committee, factory, commandParameters)
        {
            this.records = new Dictionary<string, double>();

            foreach (var recordItem in this.CommandParameters)
            {
                var recordValue = recordItem.Split('/');
                this.records.Add(recordValue[0], double.Parse(recordValue[1]));
            }
        }

        protected override IOlympian CreatePerson()
        {
            return this.Factory.CreateSprinter(this.FirstName, this.LastName, this.Country, this.records);
        }
    }
}
