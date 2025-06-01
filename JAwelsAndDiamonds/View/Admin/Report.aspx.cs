using CrystalDecisions.CrystalReports.Engine;
using JAwelsAndDiamonds.CrystalReport;
using JAwelsAndDiamonds.Dataset;
using JAwelsAndDiamonds.Handler;
using JAwelsAndDiamonds.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JAwelsAndDiamonds.View.Admin
{
    public partial class Report : System.Web.UI.Page
    {
        TransactionsHandler th = new TransactionsHandler();
        DatabaseEntities1 db = new DatabaseEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || Session["Role"].ToString() != "admin")
            {
                Response.Redirect("~/View/Home.aspx");
                return;
            }

            if (!IsPostBack)
            {
                TransactionHeader mstransaction = db.TransactionHeaders.Find(1);
                foreach (TransactionDetail item in mstransaction.TransactionDetails)
                {
                    //Debug.WriteLine(item.Name);
                }
            }

            CrystalReport1 report = new CrystalReport1();
            CrystalReportViewer1.ReportSource = report;
            DataSet1 ds = GetDataAllData(th.GetData());
            report.SetDataSource(ds);

            //TransactionReport report = new TransactionReport();
            //List<TransactionHeader> headers = th.GetData();
            //List<TransactionReportItem> data = GetData(headers);

            //report.SetDataSource(data);
            //CrystalReportViewer1.ReportSource = report;

        }

        public DataSet1 GetDataAllData(List<TransactionHeader> transactions)
        {
            DataSet1 dataset = new DataSet1();
            var headertable = dataset.TransactionHeader;
            var detailtable = dataset.TransactionDetail;

            //List<TransactionHeader> transaction;
            //transaction = db.TransactionHeaders.ToList();

            foreach (TransactionHeader t in transactions)
            {
                var hrow = headertable.NewRow();
                hrow["TransactionID"] = t.TransactionID;
                hrow["UserID"] = t.UserID;
                hrow["TransactionDate"] = t.TransactionDate;
                hrow["PaymentMethod"] = t.PaymentMethod;
                hrow["TransactionStatus"] = t.TransactionStatus;

                headertable.Rows.Add(hrow);

                if (t.TransactionDetails != null)
                {
                    foreach (var detail in t.TransactionDetails)
                    {
                        if (detail.TransactionID != t.TransactionID) continue; // ⛔ Pastikan match

                        var drow = detailtable.NewRow();
                        drow["TransactionID"] = detail.TransactionID;
                        drow["Quantity"] = detail.Quantity;
                        drow["JewelID"] = detail.JewelID;

                        int price = detail.MsJewel?.JewelPrice ?? 0;
                        drow["Price"] = price;
                        drow["Subtotal"] = price * detail.Quantity;

                        detailtable.Rows.Add(drow);
                    }
                }
            }
            
            return dataset; 
        }
    }

}