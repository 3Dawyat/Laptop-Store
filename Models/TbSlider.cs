using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class TbSlider
    {
        [Key]
        public int SliderId { get; set; }
        [MaxLength(200)]
        public string Titel { get; set; }
        [MaxLength(500)]
        public string Discribtion { get; set; }
        [MaxLength(200)]
        [Required]
        public string ImageName { get; set; }
    }
}
