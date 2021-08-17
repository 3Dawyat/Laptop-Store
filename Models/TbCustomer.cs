using System;
using System.Collections.Generic;

#nullable disable

namespace Book.Models
{
    public partial class TbCustomer
    {
        public TbCustomer()
        {
            TbCashTransactions = new HashSet<TbCashTransaction>();
            TbCustomerItems = new HashSet<TbCustomerItem>();
            TbSalesInvoices = new HashSet<TbSalesInvoice>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public virtual TbBusniesInfu TbBusniesInfu { get; set; }
        public virtual ICollection<TbCashTransaction> TbCashTransactions { get; set; }
        public virtual ICollection<TbCustomerItem> TbCustomerItems { get; set; }
        public virtual ICollection<TbSalesInvoice> TbSalesInvoices { get; set; }
    }
}
