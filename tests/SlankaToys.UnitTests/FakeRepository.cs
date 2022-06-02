using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SlankaToys.Application;

namespace SlankaToys.UnitTests
{
    public class FakeRepository<T> : IRepository<T> where T : class
    {
        public FakeRepository()
        {
        }

        public T Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
