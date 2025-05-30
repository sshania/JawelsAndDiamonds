using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsAndDiamonds.Model
{
	public class TransactionReportItem
	{
        public int TransactionID { get; set; }
        public int UserID { get; set; }
        public DateTime TransactionDate { get; set; }
        public string PaymentMethod { get; set; }
        public string TransactionStatus { get; set; }

        public int Quantity { get; set; }
        public int JewelID { get; set; }
        public int Price { get; set; }
        public int Subtotal => Price * Quantity;
    }
}