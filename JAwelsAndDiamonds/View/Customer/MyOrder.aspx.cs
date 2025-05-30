using JAwelsAndDiamonds.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JAwelsAndDiamonds.View.Customer
{
	public partial class MyOrder : System.Web.UI.Page
	{
        TransactionController tc = new TransactionController();
        protected void Page_Load(object sender, EventArgs e)
		{
            if (Session["user"] == null || Session["role"].ToString() != "customer")
            {
                Response.Redirect("~/View/Home.aspx");
                return;
            }

            if (!IsPostBack)
            {
                BindOrders();
            }
        }

        private void BindOrders()
        {
            MsUser u = (MsUser)Session["user"];
            int userId = u.UserID;
            GVOrders.DataSource = tc.GetUserTransactions(userId);
            GVOrders.DataBind();
        }

        protected void GVOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int transactionId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "ViewDetails")
            {
                Response.Redirect($"TransactionDetail.aspx?transactionId={transactionId}");
            }
            else if (e.CommandName == "ConfirmPackage")
            {
                tc.ConfirmPackage(transactionId);
                BindOrders();
            }
            else if (e.CommandName == "RejectPackage")
            {
                tc.RejectPackage(transactionId);
                BindOrders();
            }
        }
    }
}