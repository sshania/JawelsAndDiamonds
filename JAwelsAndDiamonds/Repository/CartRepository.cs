using JAwelsAndDiamonds.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsAndDiamonds.Repository
{
	public class CartRepository
	{
        private static DatabaseEntities1 db = new DatabaseEntities1();

        public static List<CartItem> GetCartItems(int userId)
        {
            using (var db = new DatabaseEntities1())
            {
                var query = from c in db.Carts
                            join j in db.MsJewels on c.JewelID equals j.JewelID
                            join b in db.MsBrands on j.BrandID equals b.BrandID
                            where c.UserID == userId
                            select new CartItem
                            {
                                JewelID = j.JewelID,
                                JewelName = j.JewelName,
                                JewelPrice = j.JewelPrice,
                                JewelBrand = b.BrandName,
                                Quantity = c.Quantity
                            };

                return query.ToList();
            }
        }

        public static void AddToCart(int userId, int jewelId, int quantity)
        {
            using (var db = new DatabaseEntities1())
            {
                System.Diagnostics.Debug.WriteLine($"AddToCart called: userId={userId}, jewelId={jewelId}, quantity={quantity}");

                var existingCartItem = GetCartItem(db, userId, jewelId);

                if (existingCartItem != null)
                {
                    existingCartItem.Quantity += quantity;
                    System.Diagnostics.Debug.WriteLine("Cart item exists. Updating quantity.");
                }
                else
                {
                    var newItem = new Cart
                    {
                        UserID = userId,
                        JewelID = jewelId,
                        Quantity = quantity
                    };
                    db.Carts.Add(newItem);
                    System.Diagnostics.Debug.WriteLine("New cart item added.");
                }

                db.SaveChanges();
                System.Diagnostics.Debug.WriteLine("Changes saved to database.");
            }
        }

        public static void DeleteCartItem(int userId, int jewelId)
        {
            var item = db.Carts.FirstOrDefault(c => c.UserID == userId && c.JewelID == jewelId);
            if (item != null)
            {
                db.Carts.Remove(item);
                db.SaveChanges();
            }
        }


        public static void UpdateCart(int userId, int jewelId, int quantity)
        {
            using (var db = new DatabaseEntities1())
            {
                var cartItem = GetCartItem(db, userId, jewelId);

                if (cartItem != null)
                {
                    cartItem.Quantity = quantity;
                    db.SaveChanges();
                }
            }
        }



        public static void UpdateCartItem(int userId, int jewelId, int quantity)
        {
            var item = db.Carts.FirstOrDefault(c => c.UserID == userId && c.JewelID == jewelId);
            if (item != null)
            {
                item.Quantity = quantity;
                db.SaveChanges();
            }
        }

        public static void ClearCart(int userId)
        {
            using (var db = new DatabaseEntities1())
            {
                var cartItems = db.Carts.Where(c => c.UserID == userId).ToList();

                if (cartItems.Any())
                {
                    db.Carts.RemoveRange(cartItems);
                    db.SaveChanges();
                }
            }
        }
        private static Cart GetCartItem(DatabaseEntities1 db, int userId, int jewelId)
        {
            return db.Carts.FirstOrDefault(c => c.UserID == userId && c.JewelID == jewelId);
        }

        private static void LogCartItems(IEnumerable<Cart> items, string message)
        {
            foreach (var item in items)
            {
                System.Diagnostics.Debug.WriteLine($"{message} - UserID: {item.UserID}, JewelID: {item.JewelID}, Quantity: {item.Quantity}");
            }
        }

    }
}