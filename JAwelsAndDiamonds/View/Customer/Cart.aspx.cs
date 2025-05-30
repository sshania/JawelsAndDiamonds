using JAwelsAndDiamonds.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JAwelsAndDiamonds.View.Customer
{
    public partial class Cart : System.Web.UI.Page
    {
        CartController cc = new CartController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || Session["role"].ToString() != "customer")
            {
                Response.Redirect("~/Views/ViewJewels.aspx");
                return;
            }

            if (!IsPostBack)
            {
                BindCart();
            }
        }

        private void BindCart()
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/View/Login.aspx");
                return;
            }

            var userEmail = ((MsUser)Session["user"]).UserEmail; 

           
            int userId;
            using (var db = new DatabaseEntities1())
            {
                var user = db.MsUsers.FirstOrDefault(u => u.UserEmail == userEmail);
                if (user == null)
                {
                    Response.Redirect("~/View/Login.aspx");
                    return;
                }
                userId = user.UserID;
            }

            var cart = cc.GetCart(userId);

            if (cart == null || !cart.Any())
            {
                LblTotal.Text = "Your cart is empty.";
                CartGridView.DataSource = null;
                CartGridView.DataBind();
                return;
            }

            CartGridView.DataSource = cart;
            CartGridView.DataBind();

            LblTotal.Text = "Total: $" + cart.Sum(c => c.Subtotal).ToString("N2");

        }
        protected void CartGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = CartGridView.Rows[index];
            int jewelId = Convert.ToInt32(CartGridView.DataKeys[index].Value);
            TextBox txtQty = (TextBox)row.FindControl("TxtQuantity");

            if (!int.TryParse(txtQty.Text, out int qty) || qty <= 0)
            {
                ErrorLabel.Text = "Quantity must be a number greater than 0";
                return;
            }

            int userId = Convert.ToInt32(Session["userId"]);

            if (e.CommandName == "UpdateCart")
            {
                cc.UpdateCart(userId, jewelId, qty);
            }
            else if (e.CommandName == "RemoveCart")
            {
                cc.RemoveFromCart(userId, jewelId);
            }

            BindCart();
        }

        protected void CartGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void BtnClearCart_Click(object sender, EventArgs e)
        {
            MsUser u = (MsUser)Session["user"];
            int userId = u.UserID;
            cc.ClearCart(userId);
            BindCart();
        }

        protected void BtnCheckout_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DDL_Payment.SelectedValue))
            {
                return;
            }

            MsUser u = (MsUser)Session["user"];
            int userId = u.UserID ;
            string paymentMethod = DDL_Payment.SelectedValue;

            cc.Checkout(userId, paymentMethod);
            BindCart();
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;

            int jewelId = Convert.ToInt32(CartGridView.DataKeys[row.RowIndex].Value);
            TextBox txtQty = (TextBox)row.FindControl("TxtQuantity");

            if (!int.TryParse(txtQty.Text, out int qty) || qty <= 0)
            {
                ErrorLabel.Text = "Quantity must be a number greater than 0";
                return;
            }

            MsUser currentUser = (MsUser)Session["user"];
            int userId = currentUser.UserID;

            cc.UpdateCart(userId, jewelId, qty);
            BindCart();
        }

        protected void BtnRemove_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;

            int jewelId = Convert.ToInt32(CartGridView.DataKeys[row.RowIndex].Value);

            MsUser currentUser = (MsUser)Session["user"];
            int userId = currentUser.UserID;

            cc.RemoveFromCart(userId, jewelId);
            BindCart();
        }
    }
}