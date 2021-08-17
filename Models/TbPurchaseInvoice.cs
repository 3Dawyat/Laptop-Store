using System;
using System.Collections.Generic;

#nullable disable

namespace Book.Models
{
    public partial class TbPurchaseInvoice
    {
        public TbPurchaseInvoice()
        {
            TbPurchaseInvoiceItems = new HashSet<TbPurchaseInvoiceItem>();
        }

        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int SupplierId { get; set; }
        public string Notes { get; set; }

        public virtual TbSupplier Supplier { get; set; }
        public virtual ICollection<TbPurchaseInvoiceItem> TbPurchaseInvoiceItems { get; set; }
    }
}
