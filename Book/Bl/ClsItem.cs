using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Models;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Book.Bl
{
    public interface IItemServes
    {
        public List<TbItem> GetAll();
        public List<VwItemCategories> GetAllItem();
        public List<TbItem> GetRelatedItem(decimal price);
        public List<TbItem> GetUpSaleItem();
        public TbItem GetById(int id);
        public TbItem GetByIdWithImage(int id);
        public bool Add(TbItem item);
        public bool Edit(TbItem item);
        public bool Delete(int item);
    }
    public class ClsItem : IItemServes
    {
        StoreWebSite2Context ctx;
        public ClsItem(StoreWebSite2Context contxt)
        {
            ctx = contxt;
        }
        public List<TbItem> GetAll()
        {
            List<TbItem> lstItem =
                ctx.TbItems
                .Include(a => a.Category)
                .OrderByDescending(a => a.CreationDate)
                .ToList();
            return lstItem;
        }
        public TbItem GetById(int id)
        {
            TbItem Item = ctx.TbItems.FirstOrDefault(a => a.ItemId == id);
            return Item;
        }
        public bool Add(TbItem item)
        {
            try
            {
                ctx.Add<TbItem>(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Edit(TbItem item)
        {
            try
            {
                ctx.Entry(item).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(int item)
        {
            try
            {
                TbItem OldItem = ctx.TbItems.Where(a => a.ItemId == item).FirstOrDefault();
                ctx.TbItems.Remove(OldItem);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public TbItem GetByIdWithImage(int id)
        {
            TbItem Item = ctx.TbItems.Include(a => a.TbItemImages).FirstOrDefault(a => a.ItemId == id);
            return Item;
        }
        public List<TbItem> GetRelatedItem(decimal price)
        {
            decimal start = price - 3000;
            decimal end = price + 3000;
            List<TbItem> lstItem =
               ctx.TbItems.Where(a => a.SalesPrice >= start && a.SalesPrice <= end)
               .OrderBy(a => a.CreationDate)
               .ToList();
            return lstItem;
        }
        public List<TbItem> GetUpSaleItem()
        {
            var query = from item in ctx.TbItems
                        join
                        discound in ctx.TbDiscound
                        on item.ItemId equals discound.ItemId
                        where discound.EndDate >= DateTime.Now
                        select item;
            return query.ToList();
        }
        public List<VwItemCategories> GetAllItem()
        {
            List<VwItemCategories> lstItem = ctx.VwItemCategories.ToList();
            return lstItem;
        }
    }
}
