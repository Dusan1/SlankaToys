using System;
using SlankaToys.Application.Contracts;
using SlankaToys.Domain.Product;

namespace SlankaToys.Infrastructure.Repository
{
    public class ProductQueryRepository : QueryRepository<Product>, IProductQueryRepository
    {
        public ProductQueryRepository(SlankaToysDbContext _slankaToysDbContext) : base(_slankaToysDbContext)
        {
        }
    }
}
