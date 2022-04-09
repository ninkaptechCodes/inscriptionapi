using Microsoft.EntityFrameworkCore;
using Ni_Soft.InscriptionApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ni_Soft.InscriptionApi.Data.Databases
{
    public class InscriptionDbContext : DbContext
    {
        public InscriptionDbContext(DbContextOptions<InscriptionDbContext> options)
            : base(options)
        {
        }

        public DbSet<CustomerEntity> Inscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configurations.Customeronfiguration());
            //base.OnModelCreating(modelBuilder);
        }
    }
}
