using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SlankaToys.Application;

namespace SlankaToys.Infrastructure.Repository
{
    public class QueryRepository<T> : IQueryRepository<T> where T : class
    {
        protected IQueryable<T> Objects => _dbContext.Set<T>().AsNoTracking();

        private readonly SlankaToysDbContext _dbContext;
        public QueryRepository(SlankaToysDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<T>> Get()
        {
            return await Objects.ToListAsync();
        }

        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate)
        {
            return await Objects.Where(predicate).ToListAsync();
        }

        public async Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return await Objects.FirstOrDefaultAsync(predicate);
        }
    }
}
