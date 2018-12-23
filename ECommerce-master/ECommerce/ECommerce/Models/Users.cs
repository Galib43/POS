using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace ECommerce.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="User Name")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Contact { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public bool? Gender { get; set; }
        public System.DateTime JoinDate { get; set; }
        public string Ip { get; set; }

         [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dd-MM-yyyy}")]
        public System.DateTime DateOfBirth { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int CityId { get; set; }
        //public string Image { get; set; }

        public virtual ICollection<AdminUser> AdminUser { get; set; }
        public virtual ICollection<Archieve> Archieves { get; set; } 
        [ForeignKey("CityId")]
        public virtual City City { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<LogInHistory> LogInHistories { get; set; } 
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<ProductLike> ProductLikes { get; set; }
        public virtual ICollection<ProductRating> ProductRatings { get; set; }
        public virtual ICollection<UserVerified> UserVerifieds { get; set; }
    }
}