using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class ProductVerified
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int AdminUserId { get; set; }

         [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dd-MM-yyyy}")]
        public System.DateTime DateTime { get; set; }
        public string Ip { get; set; }

        [ForeignKey("ProductId")]
        public virtual AdminUser AdminUser { get; set; }
         [ForeignKey("AdminUserId")]
        public virtual Product Product { get; set; }
    }
}