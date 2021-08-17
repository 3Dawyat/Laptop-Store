using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Models;
namespace Book.Models
{
    public class ShopingCard
    {
        public ShopingCard()
        {
            listItem = new List<ShopingCardItem>();
        }
        public List<ShopingCardItem> listItem { get; set; }
        public decimal Total { get; set; }
    }
}
