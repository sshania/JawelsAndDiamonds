using JAwelsAndDiamonds.Handler;
using JAwelsAndDiamonds.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JAwelsAndDiamonds.View.Admin
{
    public partial class AddJewel : System.Web.UI.Page
    {
        JewelsHandler jh = new JewelsHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["user"] == null || Session["role"].ToString() != "admin")
            //{
            //    Response.Redirect("~/View/Home.aspx");
            //    return;
            //}

            if (!IsPostBack)
            {
                BindCategory();
                BindBrand();
            }
        }

        private void BindCategory()
        {
            List<MsCategory> categories = JewelsRepository.GetAllCategories();
            ddlCategory.DataSource = categories;
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CategoryID";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Select Category --", "0"));
        }

        private void BindBrand()
        {
            List<MsBrand> brands = JewelsRepository.GetAllBrands();
            ddlBrand.DataSource = brands;
            ddlBrand.DataTextField = "BrandName";
            ddlBrand.DataValueField = "BrandID";
            ddlBrand.DataBind();

            ddlBrand.Items.Insert(0, new ListItem("Select Brand", ""));
        }

        public void clearText()
        {
            JewelName.Text = "";
            ddlBrand.SelectedIndex = 0;
            ddlCategory.SelectedIndex = 0;
            txtPrice.Text = "";
            txtYear.Text = "";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string result = jh.cekInsert(
                JewelName.Text.Trim(),
                ddlBrand.SelectedValue,
                ddlCategory.SelectedValue,
                txtPrice.Text.Trim(),
                txtYear.Text.Trim()
            );

            lblMessage.Text = result;

            if (result == "Your Item added successfully")
            {
                clearText();
                Response.Redirect(ResolveUrl("~/View/Home.aspx"));
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(ResolveUrl("~/View/Home.aspx"));
        }

    } 
}