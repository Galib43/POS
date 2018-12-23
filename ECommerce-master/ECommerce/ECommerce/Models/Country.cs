using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Country
    {   [Key]
        public int Id { get; set; }
        [MinLength(2)]
        [Display(Name = "Country Name")]
        [Required]
        public string Name { get; set; }

      public ICollection<City> Cities{ get; set; }
    }
}