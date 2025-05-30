using JAwelsAndDiamonds.Handler;
using JAwelsAndDiamonds.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JAwelsAndDiamonds.View
{
    public partial class Site : System.Web.UI.MasterPage
    {
        userRepository ur = new userRepository();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                pnlCustomer.Visible = false;
                pnlAdmin.Visible = false;
                pnlGuest.Visible = true;

                if (Request.Cookies["userLogin"] != null)
                {
                    HttpCookie rememberMeCookie = Request.Cookies["userLogin"];
                    //string role = rememberMeCookie["Role"];

                    if (rememberMeCookie != null && rememberMeCookie.Values["email"] != null)
                    {
                        string email = rememberMeCookie.Values["email"];
                        string Role = rememberMeCookie.Values["Role"];
                        MsUser user = ur.getUser(email);
                        Session["user"] = user; 


                        if (Role.Equals("admin", StringComparison.OrdinalIgnoreCase))
                        {
                            Session["Role"] = "admin";
                            pnlGuest.Visible = false;
                            pnlAdmin.Visible = true;

                        }
                        else if (Role.Equals("customer", StringComparison.OrdinalIgnoreCase))
                        {
                            Session["Role"] = "customer";
                            pnlGuest.Visible = false;
                            pnlCustomer.Visible = true;
                        }
                        else
                        {
                            Session["Role"] = "guest";
                            pnlGuest.Visible = true;
                        }
                    }
                    else
                    {
                        pnlGuest.Visible = true;
                    }
                }else if (Session["Role"] != null)
                {
                    string role = Session["Role"].ToString();


                    if (role.Equals("admin", StringComparison.OrdinalIgnoreCase))
                    {
                        pnlGuest.Visible = false;
                        pnlAdmin.Visible = true;
                    }
                    else if (role.Equals("customer", StringComparison.OrdinalIgnoreCase))
                    {
                        pnlGuest.Visible = false;
                        pnlCustomer.Visible = true;
                    }
                    else
                    {
                        pnlGuest.Visible = true;
                    }
                }
                else
                {
                    pnlGuest.Visible = true;
                }
            }

            
            if (Session["user"] != null && Session["Role"].Equals("customer"))
            {
                pnlCustomer.Visible = true;
                MsUser user = (MsUser)Session["user"];
                HyperLink cartLink = (HyperLink)pnlCustomer.FindControl("Button_Cart");

                //HyperLink cartLink = (HyperLink)FindControl("Button_Cart");
                if (cartLink != null)
                {
                    MsUser us = (MsUser)Session["user"];
                    cartLink.NavigateUrl = $"~/View/Customer/Cart.aspx?userId={us.UserID}";
                }

                //Button_Cart.NavigateUrl = $"~/Views/Customer/Cart.aspx?userId={user.UserID}";
            }
            else
            {
                //pnlCustomer.Visible = false;

            }
        }

        protected void Btn_SignIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Login.aspx");
        }

        protected void Btn_SignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Register.aspx");
        }

        protected void Btn_SignOut_Click(object sender, EventArgs e)
        {
            foreach (string cookieKey in Request.Cookies.AllKeys)
            {
                HttpCookie cookie = new HttpCookie(cookieKey)
                {
                    Expires = DateTime.Now.AddDays(-1)
                };
                Response.Cookies.Add(cookie);
            }

            Session.Clear();
            Session.Abandon();

            Response.Redirect("~/View/Login.aspx");
        }
    }
}
