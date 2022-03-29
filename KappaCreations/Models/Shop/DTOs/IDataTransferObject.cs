namespace KappaCreations.Models.Shop.DTOs
{
    interface IDataTransferObject<T>
    {
        bool HasId { get; }

        T Map();
    }
}