using OlympicGames.Core.Contracts;
using OlympicGames.Olympics.Contracts;
using System.Collections.Generic;

namespace OlympicGames.Core.Commands
{
    public class CreateSprinterCommand : CreateOlympianCommand, ICommand
    {
        private IDictionary<string, double> records;

        public CreateSprinterCommand(IOlympicCommittee committee, IOlympicsFactory factory)
            : base(committee, factory)
        {
        }

        protected override IOlympian CreatePerson(IList<string> commandParameters)
        {
            this.records = new Dictionary<string, double>();

            foreach (var recordItem in commandParameters)
            {
                var recordValue = recordItem.Split('/');
                this.records.Add(recordValue[0], double.Parse(recordValue[1]));
            }

            return this.Factory.CreateSprinter(this.FirstName, this.LastName, this.Country, this.records);
        }
    }
}
