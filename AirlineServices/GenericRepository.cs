using AirlineContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;

namespace AirlineServices
{
    public class GenericRepository<T> : IRepository<T> where T : class

    {
        private readonly DbContext context;

        public GenericRepository(DbContext context)
        {
            this.context = context;
        }
        public void Delete(T entity)
        {
            if (entity != null)
            {
                context.Set<T>().Remove(entity);
                context.SaveChanges();
            }
        }

        public T Get(object id)
        {
            var entity = context.Set<T>().Find(id);
            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public void Insert(T model)
        {
            context.Set<T>().Add(model);
            context.SaveChanges();
        }

        public IEnumerable<T> Search(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includedProperties)
        {
            IQueryable<T> query = context.Set<T>().Where(predicate);
            if (includedProperties == null)
            {
                return query.ToList();
            }
            else
            {
                foreach (var p in includedProperties)
                {
                    query.Include(p);
                }
                return query.ToList();
            }
        }
       
        public IQueryable<TResult> Select<TResult>(Expression<Func<T, TResult>> selector)
        {
            IQueryable<T> query = context.Set<T>();
            return query.Select(selector);
        }

        public void Update(T model)
        {
            context.Set<T>().Attach(model);
            context.Entry(model).State = EntityState.Modified;
            context.SaveChanges();
        }
        public IQueryable<T> Include(params Expression<Func<T, object>>[] includes)
        {
            IDbSet<T> dbSet = context.Set<T>();

            IQueryable<T> query = null;
            foreach (var include in includes)
            {
                query = dbSet.Include(include);
            }

            return query ?? dbSet;
        }
    }
}
