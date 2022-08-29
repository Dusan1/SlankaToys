using System;
using System.Collections.Generic;
using SlankaToys.Domain.Cart;
using SlankaToys.Domain.Enums;

namespace SlankaToys.UnitTests.Builders
{
    public class CartBuilder
    {
        private DateTime _createdDate;
        private int _userId;
        private CartStatus _cartStatus;
        private List<CartItem> _cartItems = new List<CartItem>();

        public CartBuilder(DateTime createdDate, int userId)
        {
            _createdDate = createdDate;
            _userId = userId;
        }

        public CartBuilder WithStatus(CartStatus status)
        {
            _cartStatus = status;
            return this;
        }

        public CartBuilder WithCartItems(List<CartItem> items)
        {
            _cartItems.AddRange(items);
            return this;
        }

        public Cart Build()
        {
            var cart = new Cart(_createdDate, _userId, _cartStatus);
            cart.AddCartItems(_cartItems);
            return cart;
        }
    }
}

