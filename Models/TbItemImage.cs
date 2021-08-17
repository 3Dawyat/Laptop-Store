using System;
using System.Collections.Generic;

#nullable disable

namespace Book.Models
{
    public partial class TbItemImage
    {
        public int ImageId { get; set; }
        public string ImageName { get; set; }
        public int ItemId { get; set; }

        public virtual TbItem Item { get; set; }
    }
}
