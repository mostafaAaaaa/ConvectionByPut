using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Convection.DTOs
{
    public class InsertVendorDto
    {
        public InsertVendorDto()
        {
            InseragDtos = new List<InsertTagDto>();
        }
        [MaxLength(100)]
        [Required]
        public String VendorName { get; set; }
        [MaxLength(100)]
        [Required]
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
        [Required]

        public DateTime Date { get; set; }

        public List<InsertTagDto> InseragDtos { get; set; }
    }
}
