using System;
namespace SlankaToys.Domain.Cart
{
    public class CartItem : IEntity
    {
        public CartItem(decimal price, int quantity, int productId)
        {
            Quantity = quantity;
            ItemPrice = price;
            ProductId = productId;
        }

        protected CartItem()
        {

        }

        public int Id { get; set; }

        public int ProductId { get; private set; }

        public Product.Product Product { get; private set; }

        public int Quantity { get; private set; }

        public decimal ItemPrice { get; private set; }
        public int CartId { get; private set; }
        public Cart Cart { get; private set; }

        public void SetQuantity(int newQuantity)
        {
            Quantity = newQuantity;
        }
    }
}
