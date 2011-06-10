using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Linq;

namespace Infrastructure
{
    public interface IRepository<TEntity>
    {
        void Add(TEntity entity);
        TEntity Get(object primaryKey);
        void Delete(TEntity entity);
        void SaveChanges();

        IEnumerable<TEntity> All { get; }
    }

    public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly ObjectContext _context;
        private readonly ObjectSet<T> _objectSet;

        public Repository(ObjectContext context)
        {
            _context = context;
            _objectSet = _context.CreateObjectSet<T>();
        }

        public void Add(T entity)
        {
            _objectSet.AddObject(entity);
        }

        public T Get(object primaryKey)
        {
            string entityKeyName = _objectSet.EntitySet.ElementType.KeyMembers.First().Name;

            var entityKey = new EntityKey(_objectSet.EntitySet.EntityContainer.Name + "." + _objectSet.EntitySet.Name, entityKeyName, primaryKey);

            object entity = _context.GetObjectByKey(entityKey);
            return entity as T;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _objectSet.DeleteObject(entity);
        }

        public IEnumerable<T> All
        {
            get { return _objectSet; }
        }
    }
}