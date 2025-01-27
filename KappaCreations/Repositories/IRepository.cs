﻿using KappaCreations.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace KappaCreations.Repositories
{
    /// <summary>
    /// Used for handling CRUD operations to the database.
    /// </summary>
    /// <typeparam name="TEntity">A <see cref="IEntity"/> type.</typeparam>
    interface IRepository<TEntity> where TEntity : class, IEntity
    {
        /// <summary>
        /// An instance of the <see cref="TEntity"/>'s <see cref="DbSet"/>.
        /// </summary>
        DbSet<TEntity> Set { get; }

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
        /// <param name="include">A navigation property to be included with the entity instance.</param>
        /// <returns>The entity that matches the given id.</returns>
        TEntity Get(int id, string include);
        /// <summary>
        /// Finds and returns an entity from the database, based on id.
        /// </summary>
        /// <param name="id">The id of the entity.</param>
        /// <returns>The entity that matches the given id.</returns>
        Task<TEntity> GetAsync(int id);
        /// <summary>
        /// Finds and returns an entity from the database, based on id.
        /// </summary>
        /// <param name="id">The id of the entity.</param>
        /// <param name="include">A navigation property to be included with the entity instance.</param>
        /// <returns></returns>
        Task<TEntity> GetAsync(int id, string include);

        /// <summary>
        /// Returns all the entities of <see cref="TEntity"/> type from the database. Asynchronous method.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{TEntity}"/> that contains all the entities.</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();
        /// <summary>
        /// Returns all the entities of <see cref="TEntity"/> type from the database. Asynchronous method.
        /// </summary>
        /// <param name="include">A navigation property to be included with the entity instance.</param>
        /// <returns>An <see cref="IEnumerable{TEntity}"/> that contains all the entities.</returns>
        Task<IEnumerable<TEntity>> GetAllAsync(string include);
        /// <summary>
        /// Returns a number of entities from the index <paramref name="i"/>.
        /// Asynchronous method.
        /// </summary>
        /// <param name="i">The starting index.</param>
        /// <param name="n">The number of entities to be returned.</param>
        /// <returns>A <paramref name="n"/> number of entities.</returns>
        Task<IEnumerable<TEntity>> GetManyAsync(int i, int n);
        /// <summary>
        /// Returns a number of entities from the index <paramref name="i"/>.
        /// Asynchronous method.
        /// </summary>
        /// <param name="i">The starting index.</param>
        /// <param name="n">The number of entities to be returned.</param>
        /// <param name="include">A navigation property to be included with the entity instance.</param>
        /// <returns>A <paramref name="n"/> number of entities.</returns>
        Task<IEnumerable<TEntity>> GetManyAsync(int i, int n, string include);

        /// <summary>
        /// Inserts a new <see cref="TEntity"/> to the database.
        /// </summary>
        /// <param name="entity">The <see cref="TEntity"/> to be inserted.</param>
        void Add(TEntity entity);

        /// <summary>
        /// Inserts multiple <see cref="TEntity"/>s to the database.
        /// </summary>
        /// <param name="entities">The <see cref="TEntity"/>s to be inserted.</param>
        void AddRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Updates a new <see cref="TEntity"/> from the database.
        /// </summary>
        /// <param name="newEntity">The object with the values to be updated.</param>
        /// <returns><see langword="true"/> if the opreration was successful,
        /// <see langword="false"/> otherwise.</returns>
        bool Update(TEntity newEntity);

        /// <summary>
        /// Updates a new <see cref="TEntity"/> from the database. Asynchronous method.
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
        /// Deletes a <see cref="TEntity"/> from the database. Asynchronous method.
        /// </summary>
        /// <param name="id">The id of the entity.</param>
        /// <returns><see langword="true"/> if the opreration was successful,
        /// <see langword="false"/> otherwise.</returns>
        Task<bool> DeleteAsync(int id);
        /// <summary>
        /// Deletes a <see cref="TEntity"/> from the database. Asynchronous method.
        /// </summary>
        /// <param name="entity">The <see cref="TEntity"/> to be deleted.</param>
        /// <returns><see langword="true"/> if the opreration was successful,
        /// <see langword="false"/> otherwise.</returns>
        Task<bool> DeleteAsync(TEntity entity);

        /// <summary>
        /// Returns the number of the entities that exists in the database, of type <see cref="TEntity"/>.
        /// </summary>
        /// <returns>The number of the entities that exists in the database, of type <see cref="TEntity"/>.</returns>
        int Count();
        /// <summary>
        /// Returns the number of the entities that exists in the database, of type <see cref="TEntity"/>.
        /// </summary>
        /// <returns>The number of the entities that exists in the database, of type <see cref="TEntity"/>.</returns>
        Task<int> CountAsync();
    }
}