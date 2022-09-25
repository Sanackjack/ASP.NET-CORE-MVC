using System;
using System.Linq.Expressions;
using RestFulASPNET.Configs;

namespace RestFulASPNET.DTOs.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DataContext db;
        public GenericRepository(DataContext context)
        {
            db = context;
        }

        public void Add(T entity)
        {
            db.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            db.Set<T>().AddRange(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return db.Set<T>().Where(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return db.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return db.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            db.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            db.Set<T>().RemoveRange(entities);
        }
    }

}