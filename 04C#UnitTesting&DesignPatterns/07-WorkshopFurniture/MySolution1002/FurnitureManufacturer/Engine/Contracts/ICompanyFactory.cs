using FurnitureManufacturer.Models.Contracts;

namespace FurnitureManufacturer.Engine.Contracts
{
    public interface ICompanyFactory
    {
        ICompany CreateCompany(string name, string registrationNumber);
    }
}
