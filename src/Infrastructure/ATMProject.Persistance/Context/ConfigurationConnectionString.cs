using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Persistance.Context
{
    internal static class ConfigurationConnectionString
    {
        public static string ConnectionString
        { 
            get
            {
                ConfigurationManager configurationManager=new ConfigurationManager(); // Microsoft.Extensions.Configuration paketinden geliyor.
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(),"../../WebApi/ATMProject.WebAPI")); // appsettings.json dosyamızın yolunu belirtiyoruz.
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetConnectionString("SqlServerConnection"); // appsettings.json içindeki connection string'imizin adını yazdık.
            } 
        }
    }
}
