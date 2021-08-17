using System;
using System.Collections.Generic;

#nullable disable

namespace Book.Models
{
    public partial class TbCustomerItem
    {
        public int ItemId { get; set; }
        public int CustomerId { get; set; }

        public virtual TbCustomer Customer { get; set; }
        public virtual TbItem Item { get; set; }
    }
}
