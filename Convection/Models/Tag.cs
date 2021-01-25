using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Convection.Models
{
    public class Tag
    {
       
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        public int VendorId { get; set; }
        public Vendor vendor { get; set; }
    }
}
