﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class UserVerified
    {
        public int Id { get; set; }
        public int UserId { get; set; }

       [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dd-MM-yyyy}")]
        public System.DateTime DateTime { get; set; }
        public string Ip { get; set; }
        [ForeignKey("UserId")]
        public virtual Users Users { get; set; }
    }
}