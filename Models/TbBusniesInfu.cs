using System;
using System.Collections.Generic;

#nullable disable

namespace Book.Models
{
    public partial class TbBusniesInfu
    {
        public int BusniesId { get; set; }
        public string BusniesCardNum { get; set; }
        public int Phone { get; set; }
        public decimal Budget { get; set; }
        public int CustomerId { get; set; }

        public virtual TbCustomer Customer { get; set; }
    }
}
