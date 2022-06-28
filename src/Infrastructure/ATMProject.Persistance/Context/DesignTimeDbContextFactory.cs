using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Persistance.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>  // IDesignTimeDbContextFactory, Microsoft.EntityFrameworkCore.Design paketinden geliyor.
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>(); // AppDbContext'imizin constructor'ına optionBuilder ile connection string'imizin nereden geleceğini belirttik. 
            optionsBuilder.UseSqlServer(ConfigurationConnectionString.ConnectionString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
