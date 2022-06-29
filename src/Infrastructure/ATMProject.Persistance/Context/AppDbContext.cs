using ATMProject.Domain.Common;
using ATMProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Persistance.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
      

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }


        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {

           
        
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());  // oluşturduğumuz configuration class'larını otomatik olarak bulup eklememizi sağlıyor 
            // Bunu IEntityTypeConfiguration interface'ini implemente eden class'ları bul diye yorumlayabiliriz.
            base.OnModelCreating(modelBuilder);                                       // base.OnModelCreating(modelBuilder); ile özelliklerimizi çalıştırıyoruz.
        }

        public override int SaveChanges()
        {

            foreach (var entry in ChangeTracker.Entries())
                switch (entry.State)
                {
                    // Write creation date
                    case EntityState.Added when entry.Entity is BaseEntity:
                        entry.Property(nameof(BaseEntity.CreatedDate)).CurrentValue = DateTime.UtcNow;
                        break;
                    // Write modification date
                    case EntityState.Modified when entry.Entity is BaseEntity:
                        entry.Property(nameof(BaseEntity.UpdatedDate)).CurrentValue = DateTime.UtcNow;
                        break;
                }

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries())
                switch (entry.State)
                {
                    // Write creation date
                    case EntityState.Added when entry.Entity is BaseEntity:
                        entry.Property(nameof(BaseEntity.CreatedDate)).CurrentValue = DateTime.UtcNow;
                        break;
                    // Write modification date
                    case EntityState.Modified when entry.Entity is BaseEntity:
                        entry.Property(nameof(BaseEntity.UpdatedDate)).CurrentValue = DateTime.UtcNow;
                        break;
                }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
