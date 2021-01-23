using Convection.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Convection.Contexts
{
    public class ConvectionContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public ConvectionContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Vendor> vendors { get; set; }

        public DbSet<Tag> Tags { get; set; }

    }
}
