using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        [MinLength(2)]
        [Display(Name = "City Name")]
        [Required]
        public string NAME { get; set; }
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        public ICollection<Users> Userses { get; set; }
    }
}