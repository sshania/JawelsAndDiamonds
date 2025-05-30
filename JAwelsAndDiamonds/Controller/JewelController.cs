using JAwelsAndDiamonds.Factory;
using JAwelsAndDiamonds.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsAndDiamonds.Controller
{
	public class JewelController
	{
        JewelsRepository jr = new JewelsRepository();
        public string InsertJewel(string name, int brandId, int categoryId, string price, string year)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(price) || string.IsNullOrWhiteSpace(year))
            {
                return "Name, price, and year must not be empty.";
            }

            if (name.Length < 3 || name.Length > 25)
            {
                return "Jewel name must be between 3 and 25 characters.";
            }

            if (!int.TryParse(price, out int parsedPrice))
            {
                return "Price must be a valid number.";
            }

            if (parsedPrice <= 25)
            {
                return "Price must be more than $25.";
            }

            if (!int.TryParse(year, out int parsedYear))
            {
                return "Release year must be a valid number.";
            }

            int currentYear = DateTime.Now.Year;
            if (parsedYear >= currentYear)
            {
                return "Release year must be less than the current year.";
            }

            MsJewel jewel = JewelFactory.createJewel(name, brandId, categoryId, parsedPrice, parsedYear);
            JewelsRepository.InsertJewel(jewel);
            return "Your Item added successfully";

        }
        public string UpdateJewel(int id, string name, int brandId, int categoryId, string price, string year)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(price) || string.IsNullOrWhiteSpace(year))
            {
                return "Name, price, and year must not be empty.";
            }

            if (name.Length < 3 || name.Length > 25)
            {
                return "Jewel name must be between 3 and 25 characters.";
            }

            if (!int.TryParse(price, out int parsedPrice))
            {
                return "Price must be a valid number.";
            }

            if (parsedPrice <= 25)
            {
                return "Price must be more than $25.";
            }

            if (!int.TryParse(year, out int parsedYear))
            {
                return "Release year must be a valid number.";
            }

            int currentYear = DateTime.Now.Year;
            if (parsedYear >= currentYear)
            {
                return "Release year must be less than the current year.";
            }

            MsJewel jewel = JewelFactory.createJewel(name, brandId, categoryId, Convert.ToInt32(price), Convert.ToInt32(year));
            new JewelsRepository().editJewel(id, jewel);
            return "Updated Data Succeeded";
        }
    }
}