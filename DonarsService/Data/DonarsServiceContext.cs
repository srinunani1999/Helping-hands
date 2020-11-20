using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DonarsService;

namespace DonarsService.Data
{
    public class DonarsServiceContext : DbContext
    {
        public DonarsServiceContext (DbContextOptions<DonarsServiceContext> options)
            : base(options)
        {
        }

        public DbSet<DonarsService.Donar> Donar { get; set; }
    }
}
