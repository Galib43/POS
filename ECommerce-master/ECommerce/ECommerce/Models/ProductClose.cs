using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class ProductClose
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dd-MM-yyyy}")]
        public System.DateTime DateTime { get; set; }
        public int ClosingTypeId { get; set; }
         [ForeignKey("ClosingTypeId")]
        public virtual CloseType CloseType { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}