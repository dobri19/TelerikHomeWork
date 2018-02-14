namespace FurnitureManufacturer.Models.Contracts
{
    public interface ITable
    {
        decimal Length { get; }

        decimal Width { get; }

        decimal Area { get; }
    }
}
