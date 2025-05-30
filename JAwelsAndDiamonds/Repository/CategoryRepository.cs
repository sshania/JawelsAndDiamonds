using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAwelsAndDiamonds.Repository
{
	public class CategoryRepository
	{
        public static int GetCategoryIdByName(string name)
        {
            using (var db = new DatabaseEntities1())
            {
                var category = db.MsCategories.FirstOrDefault(c => c.CategoryName == name);
                return category?.CategoryID ?? 0;
            }
        }
    }
}