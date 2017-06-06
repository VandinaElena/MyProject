using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AirlineContracts
{
    public interface IRepository<T> where T:class
    {
        void Insert(T model);
        IEnumerable<T> Search (Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includedProperties);
        T Get(object id);
        IEnumerable<T> GetAll();
        void Delete(T model);
        void Update(T model);

        IQueryable<TResult> Select<TResult>(Expression<Func<T, TResult>> selector);
        IQueryable<T> Include(params Expression<Func<T, object>>[] includes);
    }
}
