using JAwelsAndDiamonds.Controller;
using JAwelsAndDiamonds.Factory;
using JAwelsAndDiamonds.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Linq;

namespace JAwelsAndDiamonds.Handler
{
	public class JewelsHandler
	{
        JewelController jc = new JewelController();
        public  string cekInsert(string name, string brandIdStr, string categoryIdStr, string price, string year)
        {
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(price) ||
                string.IsNullOrWhiteSpace(year) ||
                brandIdStr.Equals("0") ||
                categoryIdStr.Equals("0"))
            {
                return "All fields are required";
            }
            int brandId = int.Parse(brandIdStr);
            int categoryId = int.Parse(categoryIdStr);

            return jc.InsertJewel(name, brandId, categoryId, price, year);
        }

        public  string cekUpdate(int id, string name, string brand, string category, string price, string year)
        {
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(price) ||
                string.IsNullOrWhiteSpace(year) ||
                brand.Equals("0") ||
                category.Equals("0"))
            {
                return "All fields are required";
            }

            int brandId = Convert.ToInt32(brand);
            int categoryId = Convert.ToInt32(category);

            if (brandId == 0 || categoryId == 0)
            {
                return "Brand or Category not found.";
            }

            string updateResult = jc.UpdateJewel(id, name, brandId, categoryId, price, year);
            return updateResult;
        }
    }
}