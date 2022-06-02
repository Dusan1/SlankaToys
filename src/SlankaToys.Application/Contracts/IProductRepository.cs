using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SlankaToys.Domain;
using SlankaToys.Domain.Product;

namespace SlankaToys.Application.Contracts
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByIds(IEnumerable<int> ids);
        Task<Product> GetProductById(int id);
    }
}
