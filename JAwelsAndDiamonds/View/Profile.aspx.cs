using JAwelsAndDiamonds.Handler;
using JAwelsAndDiamonds.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JAwelsAndDiamonds.View
{
    public partial class Profile : System.Web.UI.Page
    {
        userRepository ur = new userRepository();
        userHandler uh = new userHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                MsUser user = (MsUser)Session["user"];
                lblUsername.Text = user.UserName;
                lblEmail.Text = user.UserEmail;

                //lblUsername.Text = Session["username"].ToString();
                //lblEmail.Text = Session["email"].ToString();
            }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            string oldPassword = txtOldPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string currentPassword = Session["password"].ToString();

            if (oldPassword != currentPassword)
            {
                lblChangePasswordMessage.Text = "Old password is incorrect.";
                return;
            }

            if (!Regex.IsMatch(newPassword, @"^[a-zA-Z0-9]{8,25}$"))
            {
                lblChangePasswordMessage.Text = "New password must be 8-25 characters and alphanumeric.";
                return;
            }

            if (newPassword != confirmPassword)
            {
                lblChangePasswordMessage.Text = "Confirm password does not match.";
                return;
            }

            string pass = uh.cekPassword(oldPassword, currentPassword, newPassword, confirmPassword);

            if (!pass.Equals(" "))
            {
                lblChangePasswordMessage.Text = uh.cekPassword(oldPassword, currentPassword, newPassword, confirmPassword);
            }
            

            Session["password"] = newPassword;

            MsUser user = ur.getUser(Session["email"].ToString());
            user.UserPassword = newPassword;

            ur.UpdateUserPassword(user);

            lblChangePasswordMessage.ForeColor = System.Drawing.Color.Green;
            lblChangePasswordMessage.Text = "Password changed successfully.";
        }
    }
}