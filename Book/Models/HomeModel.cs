using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
namespace Book.Models
{
    public class HomeModel
    {
        public IEnumerable <TbSlider>lstSlider { get; set; }
        public IEnumerable<TbItem> lstNewItems { get; set; }
        public IEnumerable<TbItem> lstAllItem { get; set; }
        public IEnumerable<TbItem> lstCategorie { get; set; }
        public IEnumerable<TbItem> lstBestSeller { get; set; }
    }
}
