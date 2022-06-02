using System;
using System.Collections.Generic;
using System.Linq;
using SlankaToys.Domain.Enums;

namespace SlankaToys.Domain.Cart
{
    public class Cart
    {
        public Cart()
        {
        }

        public Cart(DateTime date, int userId)
        {
            Date = date;
            UserId = userId;
        }

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int UserId { get; set; }

        public User.User User { get; set; }

        public CartStatus Status { get; set; }

        //public CartStatus StatusId { get; set; }

        public ICollection<CartItem> CartItems => cartItems;

        private List<CartItem> cartItems = new List<CartItem>();

        public void AddCartItems(CartItem item)
        {
            if (item.Quantity > 0) { cartItems.Add(item); }
        }

        public void RemoveCartItems(IEnumerable<CartItem> items)
        {
            items.ToList().ForEach(i => cartItems.Remove(i));
        }
    }
}
