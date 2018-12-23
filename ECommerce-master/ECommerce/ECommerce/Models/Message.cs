using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dd-MM-yyyy}")]
        public DateTime? DateTime { get; set; }
        public string Ip { get; set; }
        [Display(Name = "Message")]
        public string message1 { get; set; }
         [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
         [ForeignKey("UserId")]
        public virtual Users Users { get; set; }


    }
}