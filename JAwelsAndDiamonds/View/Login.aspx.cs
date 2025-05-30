using JAwelsAndDiamonds.Controller;
using JAwelsAndDiamonds.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JAwelsAndDiamonds.View
{
	public partial class Login : System.Web.UI.Page
	{
        //LoginController controller = new LoginController();
        UserController uc = new UserController();
        protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                if (uc.IsUserRemembered(Request))
                {
                    Response.Redirect("Home.aspx");
                }
            }
        }

        protected void Login_Btn_Click(object sender, EventArgs e)
        {
            string email = Email.Text.Trim();
            string password = Password.Text.Trim();
            bool rememberMe = RememberMeCheckBox.Checked;

            string errorMsg;
            var user = uc.Login(email, password, rememberMe, Request, Response, out errorMsg);

            //if (user == null)
            //{
            //    ErrorMessage.Text = errorMsg;
            //}
            //else
            //{
            //    Session["user"] = user;
            //    Response.Redirect("Home.aspx");
            //}

            if (user == null)
            {
                ErrorMessage.Text = errorMsg;
            }
            else
            {
                Session["user"] = user;
                Session["Role"] = user.UserRole;  
                Session["UserName"] = user.UserName;
                ErrorMessage.Text = "Sukses";
                Response.Redirect("Home.aspx");
            }
        }
    }
}