using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Models;
using Book.Bl;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
namespace Book.Controllers
{
    //[Authorize(Roles = "Admin,Moderator")]
    public class ItemsController : Controller
    {
        IItemServes itemServes;
        public ItemsController(IItemServes item)
        {
            itemServes = item;
        }
        public IActionResult Details(int id)
        {
            ItemDetails model = new ItemDetails();
            model.Item = itemServes.GetByIdWithImage(id);
            model.listRelatedItems = itemServes.GetRelatedItem(model.Item.SalesPrice);
            model.listUpsalseItems = itemServes.GetUpSaleItem();
            return View(model);
        }
        public IActionResult AddToCard(int id)
        {
            ShopingCard cardItem = HttpContext.Session.Get<ShopingCard>("Card");
            if (cardItem == null)
                cardItem = new ShopingCard();
            TbItem oItem = itemServes.GetById(id);
            ShopingCardItem shopingItem = cardItem.listItem.Where(a => a.ItemId == id).FirstOrDefault();
            if (shopingItem != null)
            {
                shopingItem.Qty++;
                shopingItem.Total = shopingItem.Qty * shopingItem.Price;
            }
            else
            {
                cardItem.listItem.Add(new ShopingCardItem()
                {
                    ItemId = oItem.ItemId,
                    ItemName = oItem.ItemName,
                    ImageName = oItem.ImageName,
                    Price = oItem.SalesPrice,
                    Qty = 1,
                    Total = oItem.SalesPrice

                });
            }
            cardItem.Total = cardItem.listItem.Sum(a => a.Total);
            HttpContext.Session.Set("Card", cardItem);
            return Redirect("/Home/Index");
        }
    }
}
