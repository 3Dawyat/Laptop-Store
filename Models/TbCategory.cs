using System;
using System.Collections.Generic;

#nullable disable

namespace Book.Models
{
    public partial class TbCategory
    {
        public TbCategory()
        {
            TbItems = new HashSet<TbItem>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<TbItem> TbItems { get; set; }
    }
}
