using Microsoft.EntityFrameworkCore;
using Proiect_PWEB.Core;
using Proiect_PWEB.Infrastructure.Data.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_PWEB.Infrastructure.Data
{
    public class PwebContext : DbContext
    {
        public PwebContext(DbContextOptions<PwebContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityConfiguration).Assembly);
        }

        public DbSet<User> User => Set<User>();
    }
}
