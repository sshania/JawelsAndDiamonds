using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace JAwelsAndDiamonds.Repository
{
	public class BrandRepository
	{
        public static int GetBrandIdByName(string name)
        {
            using (var db = new DatabaseEntities1()) 
            {
                var brand = db.MsBrands.FirstOrDefault(b => b.BrandName == name);
                return brand?.BrandID ?? 0;
            }
        }
    }
}