using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SlankaToys.Application
{
    public interface IRepository<T> where T : class
    {

        T Add(T entity);

        void Delete(T entity);

        T Update(T entity);

        Task SaveChangesAsync();
    }
}
