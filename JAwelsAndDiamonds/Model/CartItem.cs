using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsAndDiamonds.Model
{
	public class CartItem
	{
        public int JewelID { get; set; }
        public string JewelName { get; set; }
        public int JewelPrice { get; set; }
        public string JewelBrand { get; set; }
        public int Quantity { get; set; }
        public int Subtotal => JewelPrice * Quantity;

    }
}