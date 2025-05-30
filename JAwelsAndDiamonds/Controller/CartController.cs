using JAwelsAndDiamonds.Factory;
using JAwelsAndDiamonds.Model;
using JAwelsAndDiamonds.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsAndDiamonds.Controller
{
    public class CartController
    {
        public List<CartItem> GetCart(int userId)
        {
            return CartRepository.GetCartItems(userId);
        }

        public void UpdateCart(int userId, int jewelId, int qty)
        {
            CartRepository.UpdateCartItem(userId, jewelId, qty);
        }

        public void RemoveFromCart(int userId, int jewelId)
        {
            CartRepository.DeleteCartItem(userId, jewelId);
        }

        public void ClearCart(int userId)
        {
            CartRepository.ClearCart(userId);
        }

        public void Checkout(int userId, string paymentMethod)
        {
            List<CartItem> cart = GetCart(userId);
            if (!cart.Any())
                throw new Exception("Cart is empty");

            if (string.IsNullOrEmpty(paymentMethod))
                throw new Exception("Payment method must be selected");

            TransactionFactory.Checkout(userId, cart, paymentMethod);
            ClearCart(userId);
        }
    }
}