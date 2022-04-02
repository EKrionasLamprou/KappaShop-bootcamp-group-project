using System;
using System.Collections.Generic;
using System.Linq;

namespace KappaCreations.Models.Shop.DTOs
{
    public abstract class DataTransferObject<TEntity> : IDataTransferObject<TEntity>
        where TEntity : class, IEntity
    {
        private static readonly string _illegalMethodMessage =
            "Using this method from the base class is not allowed. " +
            "Use the method of the derived class instead.";

        public abstract bool HasId { get; }

        public abstract TEntity Map();

        public static object MapFrom(TEntity entity, bool camelCase = false)
            => camelCase ? MapFromWithCamelCase(entity)
                         : MapFromWithPascalCase(entity);
        public static object MapFrom(IEnumerable<TEntity> entities, bool camelCase = false)
            => camelCase ? entities.Select(entity => MapFromWithCamelCase(entity))
                         : entities.Select(entity => MapFromWithPascalCase(entity));

        protected static object MapFromWithPascalCase(TEntity entity)
            => throw new Exception(_illegalMethodMessage);  
        protected static object MapFromWithCamelCase(TEntity entity)
            => throw new Exception(_illegalMethodMessage);
    }
}