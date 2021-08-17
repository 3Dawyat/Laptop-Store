using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Models;
using Book.Bl;
using Microsoft.AspNetCore.Authorization;

namespace Book.Controllers
{
    public class HomeController : Controller
    {
        IItemServes itemServes;
        public HomeController(IItemServes item)
        {
             itemServes = item;
        }
        public IActionResult Index()
        {
            HomeModel model = new HomeModel();
            model.lstAllItem = itemServes.GetAll();
            model.lstNewItems = model.lstAllItem.Take(5).ToList();
            model.lstBestSeller = model.lstAllItem.Take(3).ToList();
            model.lstCategorie = model.lstAllItem.GroupBy(a => a.CategoryId).Select(a => a.First()).ToList();
            return View(model);
        }
    }
}
