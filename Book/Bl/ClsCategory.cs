using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Models;
namespace Book.Bl
{
    public interface ICategoryServes
    {
        public List<TbCategory> GetAll();
    }
    public class ClsCategory : ICategoryServes
    {
        StoreWebSite2Context oContext;
        public ClsCategory(StoreWebSite2Context oCntxt)
        {
            oContext = oCntxt;
        }
        public List<TbCategory> GetAll()
        {
            List<TbCategory> Categories = oContext.TbCategories.ToList();
            return Categories;
        }

    }
}
