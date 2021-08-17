using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Book.Models
{
    public partial class TbItem
    {
        public TbItem()
        {
            TbCustomerItems = new HashSet<TbCustomerItem>();
            TbItemImages = new HashSet<TbItemImage>();
            TbPurchaseInvoiceItems = new HashSet<TbPurchaseInvoiceItem>();
            TbSalesInvoiceItems = new HashSet<TbSalesInvoiceItem>();
            TbDiscound = new HashSet<TbDiscound>();
        }

        public int ItemId { get; set; }
        [Required (ErrorMessage ="Please Enter Item Name ")]
        public string ItemName { get; set; }
        [Required(ErrorMessage = "Please Enter Purchase Price ")]
        public decimal PurchasePrice { get; set; }
        [Required(ErrorMessage = "Please Enter Sales Price ")]
        public decimal SalesPrice { get; set; }
        [MaxLength(200)]
        public string ImageName { get; set; }
        public int CategoryId { get; set; }
        public  DateTime CreationDate { get; set; }

        public virtual TbCategory Category { get; set; }
        public virtual ICollection<TbDiscound>  TbDiscound { get; set; }
        public virtual ICollection<TbCustomerItem> TbCustomerItems { get; set; }
        public virtual ICollection<TbItemImage> TbItemImages { get; set; }
        public virtual ICollection<TbPurchaseInvoiceItem> TbPurchaseInvoiceItems { get; set; }
        public virtual ICollection<TbSalesInvoiceItem> TbSalesInvoiceItems { get; set; }
    }
}
