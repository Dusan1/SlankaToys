using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SlankaToys.Application.Contracts;
using SlankaToys.Domain.Cart;

namespace SlankaToys.Infrastructure.Repository
{
    public class CartQueryRepository : QueryRepository<Cart>, ICartQueryRepository
    {
        private readonly DbContext _slankaDbContext;
        public CartQueryRepository(SlankaToysDbContext slankaToysDbContext) : base(slankaToysDbContext)
        {
            _slankaDbContext = slankaToysDbContext;
        }

        public async Task<Cart> GetUserCartWithItems(int userId)
        {
            return await _slankaDbContext.Set<Cart>()
                .Include(c => c.CartItems)
                .ThenInclude(c => c.Product)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }
    }
}
