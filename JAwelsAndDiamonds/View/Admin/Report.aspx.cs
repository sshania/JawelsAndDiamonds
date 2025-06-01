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
                //var ds = GetDataAllData();
                //var rpt = new CrystalReport1();
                //rpt.SetDataSource(ds);
                //CrystalReportViewer1.ReportSource = rpt;

                CrystalReport1 report = new CrystalReport1();
                CrystalReportViewer1.ReportSource = report;
                TransactionDataset dataSet = GetData(th.GetData());
                report.SetDataSource(dataSet);
            }

            //CrystalReport1 report = new CrystalReport1();
            //CrystalReportViewer1.ReportSource = report;
            //DataSet1 ds = GetDataAllData();
            //report.SetDataSource(ds);

        }

        private static TransactionDataset GetData(List<TransactionHeader> transactions)
        {
            TransactionDataset data = new TransactionDataset();
            var headerTable = data.TransactionHeader;
            var detailTable = data.TransactionDetail;

            foreach (TransactionHeader t in transactions)
            {
                var hrow = headerTable.NewRow();
                hrow["TransactionID"] = t.TransactionID;
                hrow["UserID"] = t.UserID;
                hrow["TransactionDate"] = t.TransactionDate;
                hrow["PaymentMethod"] = t.PaymentMethod;
                hrow["TransactionStatus"] = t.TransactionStatus;
                headerTable.Rows.Add(hrow);

                if (t.TransactionDetails != null)
                {
                    foreach (var tDetail in t.TransactionDetails)
                    {
                        var drow = detailTable.NewRow();
                        drow["TransactionID"] = tDetail.TransactionID;
                        drow["Quantity"] = tDetail.Quantity;
                        drow["JewelID"] = tDetail.JewelID;
                        int price = tDetail.MsJewel?.JewelPrice ?? 0;
                        drow["Price"] = price;
                        drow["Subtotal"] = price * tDetail.Quantity;
                        detailTable.Rows.Add(drow);
                    }
                    //var detail = t.TransactionDetails;

                    //var drow = detailTable.NewRow();
                    //drow["TransactionID"] = detail.TransactionID;
                    //drow["Quantity"] = detail.Quantity;
                    //drow["JewelID"] = detail.JewelID;

                    //int price = detail.MsJewel?.JewelPrice ?? 0;
                    //drow["Price"] = price;
                    //drow["Subtotal"] = price * detail.Quantity;

                    //detailTable.Rows.Add(drow);
                }
            }

            return data;
        }



        public TransactionDataset GetDataAllData()
        {
            var ds = new TransactionDataset();
            var hdrTable = ds.TransactionHeader;
            var detailTable = ds.TransactionDetail;

            List<TransactionHeader> allDone = th.GetData();

            foreach (var thdr in allDone)
            {
                var h = hdrTable.NewRow();
                h["TransactionID"] = thdr.TransactionID;
                h["UserID"] = thdr.UserID;
                h["TransactionDate"] = thdr.TransactionDate;
                h["PaymentMethod"] = thdr.PaymentMethod;
                h["TransactionStatus"] = thdr.TransactionStatus;
                hdrTable.Rows.Add(h);

                foreach (var det in thdr.TransactionDetails)
                {
                    var d = detailTable.NewRow();
                    //d["TransactionDetailID"] = det.TransactionDetailID;
                    d["TransactionID"] = det.TransactionID;
                    d["JewelID"] = det.JewelID;
                    d["Quantity"] = det.Quantity;

                    int price = det.MsJewel?.JewelPrice ?? 0;

                    //d["JewelPrice"] = price;

                    //int  price = det.MsJewel?.JewelPrice ?? 0;
                    d["Price"] = price;
                    d["SubTotal"] = price * det.Quantity;

                    detailTable.Rows.Add(d);
                }
            }

            return ds;
        }



    }

}