using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Brand Name")]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        [MinLength(3)]
        public string Origin { get; set; }
        [Required]
        [MaxLength(2000)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

    }
}