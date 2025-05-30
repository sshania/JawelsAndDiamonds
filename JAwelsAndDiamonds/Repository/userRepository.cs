using JAwelsAndDiamonds.Factory;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsAndDiamonds.Repository
{
	public class userRepository
	{
        DatabaseEntities1 db = new DatabaseEntities1();
        userFactory uf = new userFactory();

        public MsUser getUserByEmailAndPassword(string email, string password)
        {
            return db.MsUsers.FirstOrDefault(u => u.UserEmail == email && u.UserPassword == password);
        }

        //public void addUser(string email, string username, string password, string gender, DateTime dob)
        //{
        //    MsUser u = uf.createUser(email, username, password, gender, dob);
        //    db.MsUsers.Add(u);
        //    db.SaveChanges();
        //}

        //public bool isEmailUnique(string email)
        //{
        //    return db.MsUsers.FirstOrDefault(u => u.UserEmail == email) == null;
        //}

        public void insertUser(MsUser user)
        {
            db.MsUsers.Add(user);
            db.SaveChanges();
        }

        public MsUser getUser( string email)
        {
            return db.MsUsers.FirstOrDefault(u => u.UserEmail == email);
        }
        public void UpdateUserPassword(MsUser user)
        {
            var existingUser = getUser(user.UserEmail);
            if (existingUser != null)
            {
                existingUser.UserPassword = user.UserPassword; 
                db.SaveChanges();
            }
        }

    }
}