using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SlankaToys.Application.Contracts;
using SlankaToys.Domain.Cart;

namespace SlankaToys.Infrastructure.Repository
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {

        private readonly DbContext _slankaDbContext;

        public CartRepository(SlankaToysDbContext _slankaToysDbContext) : base(_slankaToysDbContext)
        {
            _slankaDbContext = _slankaToysDbContext;
        }

        public async Task<Cart> GetUserCartWithItems(int userId)
        {
            return await _slankaDbContext.Set<Cart>()
                .Include(c => c.CartItems)
                .ThenInclude(c => c.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task<Cart> GetCart(int cartId)
        {
            return await _slankaDbContext.Set<Cart>()
                .Include(c => c.CartItems)
                .ThenInclude(c => c.Product)
                .FirstOrDefaultAsync(c => c.Id == cartId);
        }
    }
}
