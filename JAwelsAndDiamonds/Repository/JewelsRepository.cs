using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsAndDiamonds.Repository
{
	public class JewelsRepository
	{

        private static DatabaseEntities1 db = DatabaseSingleton.getInstance();

        public List<MsJewel> getAllData()
        {
            return db.MsJewels.ToList();
        }

        public static void InsertJewel(MsJewel jewel)
        {
            db.MsJewels.Add(jewel);
            db.SaveChanges();
        }

        public static List<MsCategory> GetAllCategories()
        {
            return db.MsCategories.ToList();
        }
        public static List<MsBrand> GetAllBrands()
        {
            return db.MsBrands.ToList();
        }

        public static List<MsBrand> getBrands()
        {
            List<MsBrand> brandList = new List<MsBrand>();

            var q = from brands in db.MsBrands
                        select brands;

            brandList = q.ToList();

            return brandList;
        }

        public MsJewel getById(int id)
        {
            return db.MsJewels.Find(id);
        }

        public static List<MsCategory> getCategories()
        {
            List<MsCategory> categoryList = new List<MsCategory>();

            var q = from catg in db.MsCategories
                        select catg;

            categoryList = q.ToList();
 
            return categoryList;
        }

        public void editJewel(int id, MsJewel newData)
        {
            MsJewel j = db.MsJewels.Find(id);

            if (j != null)
            {
                j.JewelName = newData.JewelName;
                j.BrandID = newData.BrandID;
                j.CategoryID = newData.CategoryID;
                j.JewelPrice = newData.JewelPrice;
                j.JewelReleaseYear = newData.JewelReleaseYear;

                db.SaveChanges();
            }

            db.SaveChanges();
        }
        public void deleteJewel(int id)
        {
            MsJewel p = db.MsJewels.Find(id);

            if (p != null)
            {
                db.MsJewels.Remove(p);
                db.SaveChanges();
            }
        }
    }
}