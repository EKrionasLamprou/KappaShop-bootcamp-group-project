using KappaCreations.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace KappaCreations.RepositoryServices
{
    /// <summary>
    /// Used for handling CRUD operations to the database.
    /// </summary>
    /// <typeparam name="TEntity">A <see cref="IEntity"/> type.</typeparam>
    interface IRepositoryService<TEntity> where TEntity : IEntity
    {
        /// <summary>
        /// An instance of the <see cref="TEntity"/>'s <see cref="DbSet"/>.
        /// </summary>
        DbSet Set { get; }

        /// <summary>
        /// Finds and returns an entity from the database, based on id.
        /// </summary>
        /// <param name="id">The id of the entity.</param>
        /// <returns>The entity that matches the given id.</returns>
        TEntity Get(int id);
        /// <summary>
        /// Finds and returns an entity from the database, based on id.
        /// </summary>
        /// <param name="id">The id of the entity.</param>
        /// <returns>The entity that matches the given id.</returns>
        Task<TEntity> GetAsync(int id);

        /// <summary>
        /// Returns all the entities of <see cref="TEntity"/> type from the database.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{TEntity}"/> that contains all the entities.</returns>
        IEnumerable<TEntity> GetAll();
        /// <summary>
        /// Returns all the entities of <see cref="TEntity"/> type from the database.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{TEntity}"/> that contains all the entities.</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Inserts a new <see cref="TEntity"/> to the database.
        /// </summary>
        /// <param name="entity">The <see cref="TEntity"/> to be inserted.</param>
        void Add(TEntity entity);
        /// <summary>
        /// Inserts a new <see cref="TEntity"/> to the database.
        /// </summary>
        /// <param name="entity">The <see cref="TEntity"/> to be inserted.</param>
        void AddAsync(TEntity entity);

        /// <summary>
        /// Updates a new <see cref="TEntity"/> from the database.
        /// </summary>
        /// <param name="newEntity">The object with the values to be updated.</param>
        /// <returns><see langword="true"/> if the opreration was successful,
        /// <see langword="false"/> otherwise.</returns>
        bool Update(TEntity newEntity);

        /// <summary>
        /// Updates a new <see cref="TEntity"/> from the database.
        /// </summary>
        /// <param name="newEntity">The object with the values to be updated.</param>
        /// <returns><see langword="true"/> if the opreration was successful,
        /// <see langword="false"/> otherwise.</returns>
        Task<bool> UpdateAsync(TEntity newEntity);

        /// <summary>
        /// Deletes a <see cref="TEntity"/> from the database.
        /// </summary>
        /// <param name="id">The id of the entity.</param>
        /// <returns><see langword="true"/> if the opreration was successful,
        /// <see langword="false"/> otherwise.</returns>
        bool Delete(int id);
        /// <summary>
        /// Deletes a <see cref="TEntity"/> from the database.
        /// </summary>
        /// <param name="entity">The <see cref="TEntity"/> to be deleted.</param>
        /// <returns><see langword="true"/> if the opreration was successful,
        /// <see langword="false"/> otherwise.</returns>
        bool Delete(TEntity entity);
        /// <summary>
        /// Deletes a <see cref="TEntity"/> from the database.
        /// </summary>
        /// <param name="id">The id of the entity.</param>
        /// <returns><see langword="true"/> if the opreration was successful,
        /// <see langword="false"/> otherwise.</returns>
        Task<bool> DeleteAsync(int id);
        /// <summary>
        /// Deletes a <see cref="TEntity"/> from the database.
        /// </summary>
        /// <param name="entity">The <see cref="TEntity"/> to be deleted.</param>
        /// <returns><see langword="true"/> if the opreration was successful,
        /// <see langword="false"/> otherwise.</returns>
        Task<bool> DeleteAsync(TEntity entity);
    }
}