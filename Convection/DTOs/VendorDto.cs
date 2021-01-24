using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Convection.DTOs
{
    public class VendorDto
    {
        [Required]
        public String VendorName { get; set; }
        [Required]
        public String Title { get; set; }
        [Required]
        [MaxLength(11)]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]

        public bool Gender { get; set; }
        [Required]

        public string Adress { get; set; }
        [Required]

        public DateTime Date { get; set; }

        public ICollection<TagDto> tagDtos { get; set; }
    }
}
