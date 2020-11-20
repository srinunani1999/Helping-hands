using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonarService
{
    public class DonarsServiceContext:DbContext
    {
        public DonarsServiceContext(DbContextOptions<DonarsServiceContext> options)
    : base(options)
        {
        }

        public virtual DbSet<DonarService.Models.Donar> Donardetails { get; set; }
    }
}
