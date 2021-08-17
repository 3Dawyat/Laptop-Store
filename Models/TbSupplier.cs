using System;
using System.Collections.Generic;

#nullable disable

namespace Book.Models
{
    public partial class TbSupplier
    {
        public TbSupplier()
        {
            TbPurchaseInvoices = new HashSet<TbPurchaseInvoice>();
        }

        public int SupplierId { get; set; }
        public string SupplierName { get; set; }

        public virtual ICollection<TbPurchaseInvoice> TbPurchaseInvoices { get; set; }
    }
}
