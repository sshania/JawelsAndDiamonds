using JAwelsAndDiamonds.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JAwelsAndDiamonds.View.Admin
{
    
	public partial class HandleOrders : System.Web.UI.Page
	{
        TransactionRepository tr = new TransactionRepository();
        protected void Page_Load(object sender, EventArgs e)
		{
            if (Session["user"] == null || Session["Role"].ToString() != "admin")
            {
                Response.Redirect("~/Views/Home.aspx");
                return;
            }

            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        public void BindGrid()
        {
            List<TransactionHeader> t = tr.getUnfinishedData();
            if (t != null)
            {
                TransactionGridView.DataSource = t;
                TransactionGridView.DataBind();
            }
        }

        protected void TransactionGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string status = DataBinder.Eval(e.Row.DataItem, "TransactionStatus").ToString();
                Button btnConfirm = (Button)e.Row.FindControl("Btn_Confirm");
                Button btnShip = (Button)e.Row.FindControl("Btn_Ship");
                Label lblArrived = (Label)e.Row.FindControl("Lbl_Arrived");

                btnConfirm.Visible = false;
                btnShip.Visible = false;
                lblArrived.Visible = false;

                if (status == "Payment Pending")
                {
                    btnConfirm.Visible = true;
                }
                else if (status == "Shipment Pending")
                {
                    btnShip.Visible = true;
                }
                else if (status == "Arrived")
                {
                    lblArrived.Visible = true;
                }
            }
        }

        protected void TransactionGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Confirm" || e.CommandName == "Ship")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int id = Convert.ToInt32(TransactionGridView.DataKeys[index].Value);

                string newStatus = e.CommandName == "Confirm" ? "Shipment Pending" : "Arrived";
                tr.updateStatus(id, newStatus);
                BindGrid();
            }
        }
    }
}