using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }
        [Required]
        public int UserId { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dd-MM-yyyy}")]
        public DateTime? DateTime { get; set; }
        public string Ip { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Comment")]
        public string Comment1 { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        [ForeignKey("UserId")]
        public virtual Users Users { get; set; }
    }
}