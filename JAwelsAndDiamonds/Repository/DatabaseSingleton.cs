using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsAndDiamonds.Repository
{
	public class DatabaseSingleton
	{

        private static DatabaseEntities1 db;

        public static DatabaseEntities1 getInstance()
        {
            if (db == null)
            {
                db = new DatabaseEntities1();
            }

            return db;
        }
    }
}