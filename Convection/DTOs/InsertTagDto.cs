using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Convection.DTOs
{
    public class InsertTagDto
    {
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
    }
}
