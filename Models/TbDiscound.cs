using Book.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class TbDiscound
    {
        [Key]
        public int ItemDescountId { get; set; }
        [Required]
        public int ItemId { get; set; }
        [Required]
        public decimal DiscountValue { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public TbItem Item { get; set; }

    }
}
