namespace KappaDatabase.Models
{
    /// <summary>
    /// An interface for all the entities that get mapped from the database.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// The entity's primary key.
        /// </summary>
        int Id { get; set; }
    }
}