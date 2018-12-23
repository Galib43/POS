using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        [Required]
        [Display(Name = "Brand")]
        public int BrandId { get; set; }
        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }
        [Required]
        [Display(Name = "Condition")]
        public int ConditionId { get; set; }
        [ForeignKey("ConditionId")]
        public Condition Condition { get; set; }
       
        [Display(Name = "User")]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Users Users { get; set; }

        [DataType(DataType.Currency)]
        [Range(0, 20000)]
        public double RegularPrice { get; set; }
        public double? OfferPrice { get; set; }
        public bool? Negotiable { get; set; }
        public string Links { get; set; }
        public string Video { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Ip { get; set; }



        public virtual ICollection<Archieve> Archieves { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<ProductClose> ProductCloses { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<ProductLike> ProductLikes { get; set; }
        public virtual ICollection<ProductRating> ProductRatings { get; set; }
        public virtual ICollection<ProductVerified> ProductVerifieds { get; set; }
    }
}