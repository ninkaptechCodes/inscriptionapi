using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ni_Soft.InscriptionApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ni_Soft.InscriptionApi.Data.Configurations
{
    public class Customeronfiguration : IEntityTypeConfiguration<CustomerEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
            builder.ToTable("Customer")
                .HasData(GetCustomers());
        }

        private IEnumerable<CustomerEntity> GetCustomers()
        {
            DateTime now = DateTime.Now;
            var result = new List<CustomerEntity>()
            {
                new CustomerEntity { Id = 1, Firstname = "Frank", Lastname = "Lacroix", CreatedOn = now, UpdatedOn = default, DeletedOn = default },
                new CustomerEntity { Id = 2, Firstname = "Marie", Lastname = "Kapinga", CreatedOn = now, UpdatedOn = default, DeletedOn = default },
                new CustomerEntity { Id = 3, Firstname = "Lea", Lastname = "Agnes", CreatedOn = now, UpdatedOn = default, DeletedOn = default }
            };
            return result;
        }
    }
}
