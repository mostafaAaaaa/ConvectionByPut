using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Convection.DTOs
{
    public class ResponseInsertVendorDto: InsertVendorDto
    {
        public int Id { get; set; }
    }
}
