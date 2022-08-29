using System;
using System.Collections.Generic;
using System.Linq;
using SlankaToys.Domain.Enums;

namespace SlankaToys.Domain.Cart
{
    public class Cart : IAggregate
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

        public DateTime Date { get; private set; }

        public int UserId { get; private set; }

        public User.User User { get; private set; }

        public CartStatus Status { get; private set; }

        public ICollection<CartItem> CartItems => cartItems;

        private List<CartItem> cartItems = new List<CartItem>();

        public void AddCartItems(List<CartItem> items)
        {
            if (items.All(it => it.Quantity > 0)) { cartItems.AddRange(items); }
        }

        public void RemoveCartItems(IEnumerable<CartItem> items)
        {
            items.ToList().ForEach(i => cartItems.Remove(i));
        }

        public Cart(DateTime createdDate, int userId, CartStatus status)
        {
            Date = createdDate;
            UserId = userId;
            Status = status;
        }
    }
}
