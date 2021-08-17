using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Bl;
using Book.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.FileProviders;

namespace Book.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ItemController : Controller
    {
        IItemServes itemsrvis;
        ICategoryServes categoryServes;
        public ItemController(IItemServes itemServes, ICategoryServes categoryServis)
        {
            itemsrvis = itemServes;
            categoryServes = categoryServis;
        }
        public IActionResult List()
        {
            return View(itemsrvis.GetAll());
        }
        public IActionResult Edit(int? id)
        {
            ViewBag.Category = categoryServes.GetAll();
            if (id != null)
            {
                return View(itemsrvis.GetById(Convert.ToInt32(id)));
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult Save(TbItem Item, IFormFile Files)
        {
            if (Files != null)
            {
                if (Files.Length > 0)
                {
                    //Getting FileName
                    var fileName = Path.GetFileName(Files.FileName);
                    //Assigning Unique Filename (Guid)
                    var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                    //Getting file Extension
                    var fileExtension = Path.GetExtension(fileName);
                    // concatenating  FileName + FileExtension
                    var newFileName = String.Concat(myUniqueFileName, fileExtension);
                    // Combines two strings into a path.
                    var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Uplude")).Root + $@"\{newFileName}";
                    using (FileStream fs = System.IO.File.Create(filepath))
                    {
                        Files.CopyTo(fs);
                        fs.Flush();
                    }
                    Item.ImageName = newFileName;
                    Item.CreationDate = DateTime.Now;
                }
            }
            if (Item.ItemId == 0)
            {
                itemsrvis.Add(Item);
            }
            else
            {
                itemsrvis.Edit(Item);
            }
            return RedirectToAction("List");
        }
        public IActionResult Delete(int Item)
        {
            itemsrvis.Delete(Item);
            return RedirectToAction("List");
        }
    }
}
