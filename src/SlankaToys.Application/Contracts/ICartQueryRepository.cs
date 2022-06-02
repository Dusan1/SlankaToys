using System;
using System.Threading.Tasks;
using SlankaToys.Domain.Cart;

namespace SlankaToys.Application.Contracts
{
    public interface ICartQueryRepository : IQueryRepository<Cart>
    {
        Task<Cart> GetUserCartWithItems(int userId);
    }

}
