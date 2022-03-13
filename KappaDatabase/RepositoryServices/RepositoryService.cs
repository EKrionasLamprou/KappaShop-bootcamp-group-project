using KappaDatabase.Database;
using KappaDatabase.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace KappaDatabase.RepositoryServices
{
    class RepositoryService<TEntity> : IRepositoryService<TEntity>
        where TEntity : IEntity
    {
        readonly ShopContext db;

        public RepositoryService() => db = new ShopContext();
        public RepositoryService(ShopContext db) => this.db = db;

        public DbSet Set { get => db.Set(typeof(TEntity)); }

        public TEntity Get(int id) => (TEntity)Set.Find(id);

        public IEnumerable<TEntity> GetAll() => (IEnumerable<TEntity>)Set;

        public void Add(TEntity entity)
        {
            Set.Add(entity);
            db.SaveChanges();
        }

        public bool Update(TEntity newEntity)
        {
            int id = newEntity.Id;
            object oldEntity = Set.Find(id);

            if (oldEntity is null)
            {
                return false;
            }
            oldEntity = newEntity;
            db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            object entity = Set.Find(id);

            if (entity is null)
            {
                return false;
            }
            Set.Remove(entity);
            db.SaveChanges();
            return true;
        }
    }
}