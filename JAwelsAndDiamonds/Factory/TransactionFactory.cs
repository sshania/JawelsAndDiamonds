using JAwelsAndDiamonds.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsAndDiamonds.Factory
{
    public class TransactionFactory
    {
        public static void Checkout(int userId, List<CartItem> cart, string paymentMethod)
        {
            using (var db = new DatabaseEntities1())
            {
                if (!cart.Any())
                    throw new Exception("Cart is empty");

                if (string.IsNullOrEmpty(paymentMethod))
                    throw new Exception("Payment method must be selected");

                TransactionHeader header = new TransactionHeader
                {
                    UserID = userId,
                    TransactionDate = DateTime.Now,
                    PaymentMethod = paymentMethod,
                    TransactionStatus = "Payment Pending"
                };

                db.TransactionHeaders.Add(header);
                db.SaveChanges();

                foreach (var item in cart)
                {
                    TransactionDetail detail = new TransactionDetail
                    {
                        TransactionID = header.TransactionID,
                        JewelID = item.JewelID,
                        Quantity = item.Quantity,
                        // JewelPrice = item.JewelPrice // jangan dipakai
                    };
                    db.TransactionDetails.Add(detail);
                }

                db.SaveChanges();
            }
        }
    }
}