﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Convection.DTOs
{
    public class UpdateTagDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
