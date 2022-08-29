using System.Threading.Tasks;
using SlankaToys.Domain.Cart;
using SlankaToys.Domain.Product;
using SlankaToys.Infrastructure.Repository;

namespace SlankaToys.UnitTests.Builders
{
    public class TestDataBuilder
    {
        private readonly TestContextFactory _contextFactory;
        public CartRepository CartRepository;
        public ProductRepository ProductRepository;

        public TestDataBuilder(TestContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            CartRepository = new CartRepository(_contextFactory.SlankaToysDbContext);
            ProductRepository = new ProductRepository(_contextFactory.SlankaToysDbContext);
        }

        public async Task WithCart(Cart cart)
        {
            CartRepository.Add(cart);
            await CartRepository.SaveChangesAsync();
        }

        public async Task WithProduct(Product product)
        {
            ProductRepository.Add(product);
            await ProductRepository.SaveChangesAsync();
        }
    }
}

