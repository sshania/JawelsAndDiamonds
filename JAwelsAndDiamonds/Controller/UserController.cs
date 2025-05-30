using JAwelsAndDiamonds.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace JAwelsAndDiamonds.Controller
{
    public class UserController
	{
        private userHandler userHandler = new userHandler();

        public MsUser Login(string email, string password, bool rememberMe, HttpRequest req, HttpResponse res, out string errorMsg)
        {
            errorMsg = "";

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                errorMsg = "Email dan password harus diisi.";
                return null;
            }

            return userHandler.DoLogin(email, password, rememberMe, req, res, out errorMsg);
        }

        public bool IsUserRemembered(HttpRequest req)
        {
            return userHandler.CheckRememberCookie(req);
        }

        public bool RegisterUser(string email, string username, string password, string confirmPassword, string gender, DateTime dob, out string errorMsg)
        {
            errorMsg = "";

            if (string.IsNullOrEmpty(email) || !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                errorMsg = "Email tidak valid.";
                return false;
            }

            if (string.IsNullOrEmpty(username) || username.Length < 3 || username.Length > 25)
            {
                errorMsg = "Username harus 3-25 karakter.";
                return false;
            }

            if (string.IsNullOrEmpty(password) || password.Length < 8 || password.Length > 20 || !Regex.IsMatch(password, @"^[a-zA-Z0-9]+$"))
            {
                errorMsg = "Password harus 8-20 karakter alfanumerik.";
                return false;
            }

            if (password != confirmPassword)
            {
                errorMsg = "Konfirmasi password tidak cocok.";
                return false;
            }

            if (gender != "Male" && gender != "Female")
            {
                errorMsg = "Gender harus dipilih.";
                return false;
            }

            if (dob == DateTime.MinValue || dob >= new DateTime(2010, 1, 1))
            {
                errorMsg = "Tanggal lahir harus sebelum 01/01/2010.";
                return false;
            }

            return userHandler.DoRegister(email, username, password, gender, dob, out errorMsg);
        }
    }
}