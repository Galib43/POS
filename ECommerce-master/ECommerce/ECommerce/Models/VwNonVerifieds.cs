using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class VwNonVerifieds
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool? Gender { get; set; }

         [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dd-MM-yyyy}")]
        public System.DateTime JoinDate { get; set; }
        public string Ip { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string Address { get; set; }

    }
}