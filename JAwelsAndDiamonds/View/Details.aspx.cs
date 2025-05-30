using JAwelsAndDiamonds.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JAwelsAndDiamonds.View
{
	public partial class Details : System.Web.UI.Page
	{
        JewelsRepository jr = new JewelsRepository();
        protected void Page_Load(object sender, EventArgs e)
		{
            string id = Request.QueryString["id"];

            if (string.IsNullOrEmpty(id) || !int.TryParse(id, out int jewelId))
            {
                Response.Redirect("~/Views/Home.aspx");
                return;
            }

            if (!IsPostBack)
            {
                loadData(jewelId);
            }
        }

        private void loadData(int jewelID)
        {
            MsJewel jewel = jr.getById(jewelID);
            if (jewel != null)
            {
                lblJewelName.Text = jewel.JewelName;
                lblJewelCategory.Text = jewel.MsCategory.CategoryName;
                lblJewelBrand.Text = jewel.MsBrand.BrandName;
                lblCountryOrigin.Text = jewel.MsBrand.BrandCountry;
                lblClass.Text = jewel.MsBrand.BrandClass;
                lblPrice.Text = jewel.JewelPrice.ToString();
                lblReleaseYear.Text = jewel.JewelReleaseYear.ToString();

                string role = Session["role"] as string;

                if (string.IsNullOrEmpty(role))
                {
                    Response.Redirect("~/View/Register.aspx");
                    return;
                }
                else if (role == "admin")
                {
                    adminButtons.Visible = true;
                    addToCartBtn.Visible = false;
                }
                else if (role == "customer")
                {
                    adminButtons.Visible = false;
                    addToCartBtn.Visible = true;
                }
                else
                {
                    adminButtons.Visible = false;
                    addToCartBtn.Visible = false;
                }
            }
            else
            {
                Response.Redirect("~/View/Home.aspx");
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            //string id = Request.QueryString["id"];
            if (int.TryParse(Request.QueryString["id"], out int jewelId))
            {
                Response.Redirect("~/View/Admin/UpdateJewel.aspx?id=" + jewelId);
            }
            else
            {
                Response.Redirect("~/View/Home.aspx");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Request.QueryString["id"], out int jewelId))
            {
                jr.deleteJewel(jewelId);
            }
            Response.Redirect("~/Views/Home.aspx");
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("~/View/Login.aspx");
                return;
            }

            MsUser currentUser = (MsUser)Session["user"];
            int userId = currentUser.UserID;

            string idParam = Request.QueryString["id"];
            if (string.IsNullOrEmpty(idParam) || !int.TryParse(idParam, out int jewelId))
            {
                Response.Redirect("~/View/Home.aspx");
                return;
            }

            int quantity = 1;
            CartRepository.AddToCart(userId, jewelId, quantity);
            Response.Redirect($"~/View/Customer/Cart.aspx?userId={userId}");
        }
    }
}