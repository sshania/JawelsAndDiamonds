using JAwelsAndDiamonds.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsAndDiamonds.Factory
{
    public class userFactory
	{
        //userRepository up = new userRepository(); 
        public MsUser createUser(string email, string username, string password, string gender, DateTime dob)
        {
            MsUser u = new MsUser();
            u.UserEmail = email;
            u.UserName = username;
            u.UserPassword = password;
            u.UserGender = gender;
            u.userDOB = dob;
            u.UserRole = "customer";

            return u;
        }


    }
}