using System;
using System.Collections.Generic;

namespace Models
{
    public partial class VwItemCategories
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal SalesPrice { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public decimal PurchasePrice { get; set; }
        public string ImageName { get; set; }
    }
}
