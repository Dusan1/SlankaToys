using System.Threading.Tasks;
using SlankaToys.Domain.Cart;

namespace SlankaToys.Application.Contracts
{
    public interface ICartRepository : IRepository<Cart>
    {
        Task<Cart> GetUserCartWithItems(int userId);
        Task<Cart> GetCart(int cartId);
    }
}
