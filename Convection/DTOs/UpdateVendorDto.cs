﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Convection.DTOs
{
    public class UpdateVendorDto
    {
        public UpdateVendorDto()
        {
            InseragDtos = new List<UpdateTagDto>();
        }
        [Required]
        [MaxLength(100)]
        public String VendorName { get; set; }
        [Required]
        [MaxLength(100)]
        public String Title { get; set; }
        [Required]
        [MaxLength(11)]

        public string PhoneNumber { get; set; }
        [MaxLength(100)]
        [Required]
        public string Email { get; set; }
        [Required]

        public bool Gender { get; set; }
        [Required]
        [MaxLength(200)]
        public string Adress { get; set; }

        public DateTime Date { get; set; }

        public List<UpdateTagDto> InseragDtos { get; set; }
    }
}
