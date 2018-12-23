using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class CloseType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Close Type")]
        public string Name { get; set; }
        [StringLength(200, MinimumLength = 3)]
        [DataType(DataType.MultilineText)]
        public string Decription { get; set; }
        public virtual ICollection<ProductClose> ProductCloses { get; set; }
    }
}