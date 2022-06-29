using ATMProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Persistance.Context.Configurations
{

    internal class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            //builder.HasKey(c => c.Id);
            //builder.Property(c => c.Id).UseIdentityColumn();
            //builder.ToTable("Accounts");

            //builder.HasOne(x => x.Customer).WithMany(a => a.Accounts).HasForeignKey(b => b.CustomerId);
        }
    }
}
