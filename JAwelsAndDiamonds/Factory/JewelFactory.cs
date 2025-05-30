using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsAndDiamonds.Factory
{
	public class JewelFactory
	{
        public static MsJewel createJewel(string name, int brandId, int catId, int price, int year)
        {
            return new MsJewel
            {
                JewelName = name,
                BrandID = brandId,
                CategoryID = catId,
                JewelPrice = price,
                JewelReleaseYear = year
            };
        }

    }
}