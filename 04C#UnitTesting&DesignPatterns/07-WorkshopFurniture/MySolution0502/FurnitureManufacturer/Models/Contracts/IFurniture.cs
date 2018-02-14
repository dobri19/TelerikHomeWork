namespace FurnitureManufacturer.Models.Contracts
{
    public interface IFurniture
    {
        string Model { get; }

        string Material { get; }

        decimal Price { get; }

        decimal Height { get; }
    }
}
