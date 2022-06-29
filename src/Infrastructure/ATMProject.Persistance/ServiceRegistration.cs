using ATMProject.Application.Interfaces.Repositories;
using ATMProject.Application.Interfaces.Services;
using ATMProject.Persistance.Context;
using ATMProject.Persistance.Repositories;
using ATMProject.Persistance.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Persistance
{
    public static class ServiceRegistration
    {
        // Her katmanda bağımlılıkları barındıran bir static class oluşturuyoruz. Bu class'larıda WebAPI tarafında program.cs içinde çağırarak bağımlılıkların çalışmasını sağlıyoruz.
        // WebAPI tarafında program.cs içinde şu kod satırı ile çağırıyoruz: builder.Services.PersistenceRegisterService();
        public static void AddPersistenceRegisterService(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(ConfigurationConnectionString.ConnectionString));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //  services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            //services.AddScoped<IBankRepository, BankRepository>();
            //services.AddScoped<IAccountRepository, AccountRepository>();
        }
    }
}
