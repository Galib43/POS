using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Category Name")]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]

        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public virtual ICollection<Category> Category1 { get; set; }
        public virtual Category Category2 { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}