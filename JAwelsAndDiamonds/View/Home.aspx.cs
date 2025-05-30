using JAwelsAndDiamonds.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JAwelsAndDiamonds.View
{
	public partial class Home : System.Web.UI.Page
	{
        JewelsRepository jr = new JewelsRepository();
        protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                DataBindJewels();
            }
        }

        private void DataBindJewels()
        {
            GridView1.DataSource = jr.getAllData();
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}