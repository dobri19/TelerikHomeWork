using FurnitureManufacturer.Engine.Contracts;
using FurnitureManufacturer.Models;
using FurnitureManufacturer.Models.Contracts;

namespace FurnitureManufacturer.Engine.Factories
{
    public class CompanyFactory : ICompanyFactory
    {
        public ICompany CreateCompany(string name, string registrationNumber)
        {
            return new Company(name, registrationNumber);
        }
    }
}
