using JAwelsAndDiamonds.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JAwelsAndDiamonds.View
{
	public partial class Register : System.Web.UI.Page
	{
        //RegisterController rc = new RegisterController();
        UserController uc = new UserController();
        protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                if (Session["user"] != null) Response.Redirect("Home.aspx");
            }
        }

        protected void Register_Btn_Click(object sender, EventArgs e)
        {
            string email = Email.Text.Trim();
            string username = Username.Text.Trim();
            string password = Password.Text;
            string confirmPassword = ConfirmPassword.Text;
            string gender = GenderList.SelectedValue;
            string dobInput = TxtDOB.Text.Trim();

            DateTime dob;
            string errorMsg;

            if (!DateTime.TryParse(dobInput, out dob))
            {
                ErrorMessage.Text = "Format tanggal lahir tidak valid.";
                return;
            }

            bool isSuccess = uc.RegisterUser(email, username, password, confirmPassword, gender, dob, out errorMsg);

            if (!isSuccess)
            {
                ErrorMessage.ForeColor = System.Drawing.Color.Red;
                ErrorMessage.Text = errorMsg;
            }
            else
            {
                ErrorMessage.ForeColor = System.Drawing.Color.Green;
                //ErrorMessage.Text = "Success. Go login.";
                Response.Redirect("Login.aspx");
            }
        }
    }
}