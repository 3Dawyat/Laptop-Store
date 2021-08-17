using System;
using System.Collections.Generic;

#nullable disable

namespace Book.Models
{
    public partial class FinalyInvoice
    {
        public string ItemName { get; set; }
        public string CategoryName { get; set; }
        public double Qty { get; set; }
        public decimal InvoicePrice { get; set; }
        public double? Total { get; set; }
        public string CustomerName { get; set; }
        public DateTime InvoiceDate { get; set; }
    }
}
