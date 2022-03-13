using KappaDatabase.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace KappaDatabase.RepositoryServices
{
    interface IRepositoryService<TEntity> where TEntity : IEntity
    {
        DbSet Set { get; }

        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        bool Update(TEntity newEntity);
        bool Delete(int id);
    }
}