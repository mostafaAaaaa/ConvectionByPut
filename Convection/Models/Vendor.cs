﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Convection.Models
{

    public class Vendor
    {
        public Vendor()
        {

            Tags = new HashSet<Tag>();
        }
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public String VendorName { get; set; }
        [Required]
        [MaxLength(100)]
        public String Title { get; set; }
        [MaxLength(11)]
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        [Required]

        public bool Gender { get; set; }
        [Required]
        [MaxLength(200)]
        public string Adress { get; set; }

        public DateTime Date { get; set; }



        public ICollection<Tag> Tags { get; set; }
    }

}
