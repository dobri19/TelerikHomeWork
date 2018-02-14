using FurnitureManufacturer.Commands.Contracts;
using FurnitureManufacturer.Engine;
using FurnitureManufacturer.Engine.Contracts;
using System.Collections.Generic;

namespace FurnitureManufacturer.Commands.Company
{
    public class ShowCompanyCatalogCommand : ICommand
    {
        private readonly IDataStore data;
        private readonly Constants constants;

        public ShowCompanyCatalogCommand(IDataStore data, Constants constants)
        {
            this.data = data;
            this.constants = constants;
        }

        public string Execute(IList<string> parameters)
        {
            var companyName = parameters[0];

            if (!this.data.Companies.ContainsKey(companyName))
            {
                return string.Format(this.constants.CompanyNotFoundErrorMessage, companyName);
            }

            return this.data.Companies[companyName].Catalog();
        }
    }
}
