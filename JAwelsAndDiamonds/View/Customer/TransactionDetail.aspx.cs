using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Util;
using JAwelsAndDiamonds.Handler;

namespace JAwelsAndDiamonds.View.Customer
{
	public partial class TransactionDetail : System.Web.UI.Page
	{
        //TransactionsHandler th = new TransactionsHandler();
        protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                if (Session["Role"] == null || Session["Role"].ToString() != "customer")
                {
                    Response.Redirect("~/View/Home.aspx");
                    return;
                }

                // Ambil transactionId dari QueryString
                if (int.TryParse(Request.QueryString["transactionId"], out int transactionId))
                {
                    LoadTransactionDetails(transactionId);
                }
                else
                {
                    Response.Redirect("~/View/Customer/MyOrder.aspx");
                }
            }
        }
        private void LoadTransactionDetails(int id)
        {
            using (var db = new DatabaseEntities1())
            {
                var transactionDetails = (from th in db.TransactionHeaders
                                          join td in db.TransactionDetails on th.TransactionID equals td.TransactionID
                                          join jewel in db.MsJewels on td.JewelID equals jewel.JewelID
                                          where th.TransactionID == id
                                          select new
                                          {
                                              th.TransactionID,
                                              JewelName = jewel.JewelName,
                                              td.Quantity
                                          }).ToList();

                if (transactionDetails.Any())
                {
                    TransactionId.Text = id.ToString(); 

                    GVTransactionDetails.DataSource = transactionDetails;
                    GVTransactionDetails.DataBind();
                }
                else
                {
                    Response.Redirect("~/View/Customer/MyOrder.aspx");
                }
            }
            
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Customer/MyOrder.aspx");
        }
    }
}