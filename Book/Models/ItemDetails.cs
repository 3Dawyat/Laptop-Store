using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Models
{
    public class ItemDetails
    {
        public TbItem Item { get; set; }
        public List<TbItem> listRelatedItems{ get; set; }
        public List<TbItem> listUpsalseItems { get; set; }
    }
}
