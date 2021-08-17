using Book.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult ShopingCard()
        {
            ShopingCard cardItem = HttpContext.Session.Get<ShopingCard>("Card");
            if (cardItem == null)
            {
                return Redirect("/Home/Index");
            }
            else
            {
                return View(cardItem);
            }
        }
        public IActionResult RemoveItem(int id)
        {
            ShopingCard cardItem = HttpContext.Session.Get<ShopingCard>("Card");
            cardItem.listItem.Remove(cardItem.listItem.Where(a => a.ItemId == id).FirstOrDefault());
            cardItem.Total = cardItem.listItem.Sum(a => a.Total);
            HttpContext.Session.Set("Card", cardItem);
            return Redirect("/Order/ShopingCard");
        }
    }
}
