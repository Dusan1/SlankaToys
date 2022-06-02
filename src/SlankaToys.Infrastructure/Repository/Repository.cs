using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SlankaToys.Application;

namespace SlankaToys.Infrastructure.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected IQueryable<T> ObjectsList => _dbContext.Set<T>(); 

        private readonly SlankaToysDbContext _dbContext;
        public Repository(SlankaToysDbContext dbContext)
        {
            //_unitOfWork = unitOfWork;
            _dbContext = dbContext;
        }
        public T Add(T entity)
        {
            return _dbContext.Set<T>().Add(entity).Entity;
        }

        public void Delete(T entity)
        {
            T existing = _dbContext.Set<T>().Find(entity);
            if (existing != null) _dbContext.Set<T>().Remove(existing);
        }

        public T Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return _dbContext.Set<T>().Attach(entity).Entity;
        }


        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
