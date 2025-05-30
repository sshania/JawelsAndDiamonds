using JAwelsAndDiamonds.Factory;
using JAwelsAndDiamonds.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace JAwelsAndDiamonds.Handler
{
        public class userHandler
        {
        private userRepository userRepository = new userRepository();
        private userFactory userFactory = new userFactory();

        public MsUser DoLogin(string email, string password, bool remember, HttpRequest req, HttpResponse res, out string errorMsg)
        {
            errorMsg = "";

            MsUser user = userRepository.getUserByEmailAndPassword(email, password);
            if (user == null)
            {
                errorMsg = "Email atau password salah.";
                return null;
            }

            req.RequestContext.HttpContext.Session["Email"] = email;
            req.RequestContext.HttpContext.Session["Username"] = user.UserName;
            req.RequestContext.HttpContext.Session["Password"] = password;
            req.RequestContext.HttpContext.Session["Role"] = user.UserRole.ToLower();
            req.RequestContext.HttpContext.Session["user"] = user;
            //Session["user"] = user;

            if (remember)
            {
                MsUser u = userRepository.getUser(email);

                HttpCookie cookie = new HttpCookie("UserLogin");
                cookie["Email"] = email;
                cookie["Password"] = password;
                cookie["Username"] = u.UserName;    
                cookie["Role"] = u.UserRole.ToLower();
                //cookie["user"] = u;


                cookie.Expires = DateTime.Now.AddDays(7);
                res.Cookies.Add(cookie);
            }

            return user;
        }

        public bool CheckRememberCookie(HttpRequest req)
        {
            HttpCookie cookie = req.Cookies["userLogin"];
            if (cookie != null)
            {
                string email = cookie["Email"];
                string password = cookie["Password"];
                string Role = cookie["Role"];
                string username = cookie["Username"];

                var user = userRepository.getUserByEmailAndPassword(email, Role);
                return user != null;
            }

            return false;
        }

        public bool DoRegister(string email, string username, string password, string gender, DateTime dob, out string errorMsg)
        {
            errorMsg = "";

            if (userRepository.getUser(email) != null)
            {
                errorMsg = "Email sudah digunakan.";
                return false;
            }

            MsUser user = userFactory.createUser(email, username, password, gender, dob);
            userRepository.insertUser(user);
            return true;
        }

        public string cekPassword(string oldPassword, string currentPassword, string newPassword, string confirmPassword)
        {
            if (oldPassword != currentPassword)
            {
                return "Old password is incorrect.";
            }

            if (!Regex.IsMatch(newPassword, @"^[a-zA-Z0-9]{8,25}$"))
            {
                return "New password must be 8-25 characters and alphanumeric.";
            }

            if (newPassword != confirmPassword)
            {
                return "Confirm password does not match.";
            }

            return "";
        }
    }
}