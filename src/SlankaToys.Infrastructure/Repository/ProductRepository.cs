using SlankaToys.Infrastructure.Repository;
using SlankaToys.Infrastructure.UnitOfWork;
using SlankaToys.Domain;
using SlankaToys.Application.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using SlankaToys.Domain.Product;

namespace SlankaToys.Infrastructure.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly DbContext _slankaDbContext;
        public ProductRepository(SlankaToysDbContext _slankaToysDbContext) : base(_slankaToysDbContext)
        {
            _slankaDbContext = _slankaToysDbContext;
        }

        public async Task<IEnumerable<Product>> GetProductsByIds(IEnumerable<int> ids)
        {
            return await _slankaDbContext.Set<Product>().Where(p => ids.Contains(p.Id)).ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _slankaDbContext.Set<Product>().FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
