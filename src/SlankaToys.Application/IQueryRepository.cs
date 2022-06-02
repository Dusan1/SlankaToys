using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SlankaToys.Application
{
    public interface IQueryRepository<T> where T : class
    {
        Task<IEnumerable<T>> Get();
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate);

        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate);
    }
}
