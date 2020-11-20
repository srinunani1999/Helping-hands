using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HelpingHandsApi.Models;

namespace HelpingHandsApi.Data
{
    public class HelpingHandsApiContext : DbContext
    {
        public HelpingHandsApiContext (DbContextOptions<HelpingHandsApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HelpingHandsApi.Models.Organization> Organization { get; set; }

        public DbSet<HelpingHandsApi.Models.Donar> Donar { get; set; }
    }
}
