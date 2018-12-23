using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class ProductImage
    { 
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string Title { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}