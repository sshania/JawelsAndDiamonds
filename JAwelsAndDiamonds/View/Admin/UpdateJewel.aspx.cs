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
	public partial class UpdateJewel : System.Web.UI.Page
	{
        JewelsRepository jr = new JewelsRepository();
        JewelsHandler jh = new JewelsHandler();
        protected void Page_Load(object sender, EventArgs e)
		{
            int id = Convert.ToInt32(Request["id"]);

            if (!IsPostBack)
            {
                
                BindBrand();
                BindCategory();
                loadData(id);
            }
        }

        private void loadData(int jewelId)
        {
            MsJewel jewels = jr.getById(jewelId);

            JewelName.Text = jewels.JewelName;
            ddlBrand.SelectedValue = jewels.BrandID.ToString();
            ddlCategory.SelectedValue = jewels.CategoryID.ToString();
            txtPrice.Text = jewels.JewelPrice.ToString();
            txtYear.Text = jewels.JewelReleaseYear.ToString();
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request["id"]);
            MsJewel jewels = jr.getById(id);

            string name = JewelName.Text;
            string brand = ddlBrand.SelectedValue;
            string category = ddlCategory.SelectedValue;
            string price = txtPrice.Text;
            string releaseYear = txtYear.Text;

            if (ddlBrand.SelectedIndex == 0 || ddlCategory.SelectedIndex == 0)
            {
                errorMsg.Text = "Please select a valid brand and category.";
                return;
            }

            string error = jh.cekUpdate(id, name, brand, category, price, releaseYear);

            if (error == "successfully updated")
            {
                errorMsg.Text = "Jewel updated successfully.";
                // redirect atau refresh data
            }
            else
            {
                errorMsg.Text = error;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Home.aspx");
        }
    }
}