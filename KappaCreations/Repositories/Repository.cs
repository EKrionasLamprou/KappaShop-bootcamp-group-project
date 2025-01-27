﻿using KappaCreations.Database;
using KappaCreations.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace KappaCreations.Repositories
{
    /// <summary>
    /// Used for handling CRUD operations to the database. Generic class.
    /// </summary>
    /// <typeparam name="TEntity">A <see cref="IEntity"/> type.</typeparam>
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        protected readonly ShopContext db;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}" class/>.
        /// Opens a new connection with the database.
        /// </summary>
        public Repository() => db = new ShopContext();

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}" class/>.
        /// </summary>
        /// <param name="db">An instance of the database.</param>
        public Repository(ShopContext db) => this.db = db;
        
        public virtual DbSet<TEntity> Set { get => db.Set<TEntity>(); }

        public virtual TEntity Get(int id) => Set.Find(id);
        public virtual TEntity Get(int id, string include) => Set.Where(e => e.Id == id)
                                                                 .Include(include)
                                                                 .SingleOrDefault();
        public virtual async Task<TEntity> GetAsync(int id)
            => await Set.FindAsync(id);
        public virtual async Task<TEntity> GetAsync(int id, string include)
            => await Set.Where(e => e.Id == id)
                        .Include(include)
                        .SingleOrDefaultAsync();

        public virtual async Task<IEnumerable<TEntity>> GetManyAsync(int i, int n)
            => await Set.Skip(i).Take(n).ToListAsync();

        public virtual async Task<IEnumerable<TEntity>> GetManyAsync(int i, int n,
            string include)
            => await Set.Skip(i).Take(n).Include(include).ToListAsync();

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
            => await Set.ToListAsync();
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(string include)
            => await Set.Include(include).ToListAsync();

        public virtual void Add(TEntity entity) => Set.Add(entity);

        public virtual void AddRange(IEnumerable<TEntity> entities)
            => Set.AddRange(entities);

        public virtual bool Update(TEntity newEntity)
        {
            int id = newEntity.Id;
            TEntity oldEntity = Get(id);

            if (oldEntity is null)
            {
                return false;
            }
            db.Entry(oldEntity).CurrentValues.SetValues(newEntity);
            return true;
        }
        public virtual async Task<bool> UpdateAsync(TEntity newEntity)
        {
            int id = newEntity.Id;
            TEntity oldEntity = await GetAsync(id);

            if (oldEntity is null)
            {
                return false;
            }
            db.Entry(oldEntity).CurrentValues.SetValues(newEntity);
            return true;
        }

        public virtual bool Delete(int id)
        {
            TEntity entity = Get(id);

            if (entity is null)
            {
                return false;
            }
            Set.Remove(entity);
            return true;
        }
        public virtual bool Delete(TEntity entity) => Delete(entity.Id);
        public virtual async Task<bool> DeleteAsync(int id)
        {
            TEntity entity = await GetAsync(id);

            if (entity is null)
            {
                return false;
            }
            Set.Remove(entity);
            return true;
        }
        public virtual async Task<bool> DeleteAsync(TEntity entity)
            => await DeleteAsync(entity.Id);

        public int Count() => Set.Count();
        public Task<int> CountAsync() => Set.CountAsync();
    }
}