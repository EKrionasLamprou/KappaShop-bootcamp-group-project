namespace KappaCreations.Models.Shop.DTOs
{
    interface IDataTransferObject<T>
    {
        /// <summary>
        /// <see langword="true"/> the object has a valid, non-null id,
        /// otherwise <see langword="false"/>.
        /// </summary>
        bool HasId { get; }

        /// <summary>
        /// Returns a <see cref="T"/> object, by mapping the properties of this
        /// <see cref="IDataTransferObject"/>
        /// </summary>
        /// <returns>An instance of a <see cref="T"/> object.</returns>
        T Map();
    }
}