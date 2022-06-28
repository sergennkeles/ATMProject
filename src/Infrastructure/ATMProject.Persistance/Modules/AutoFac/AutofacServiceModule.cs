using Module = Autofac.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMProject.Persistance.Repositories;
using ATMProject.Application.Interfaces.Repositories;
using Autofac;
using ATMProject.Application.Interfaces.Services;
using ATMProject.Persistance.Services;
using ATMProject.Persistance.UnitOfWorks;
using ATMProject.Application.Interfaces.UnitOfWorks;
using System.Reflection;
using ATMProject.Persistance.Context;

namespace ATMProject.Persistance.Modules.AutoFac
{
    public class AutofacServiceModule:Module
    {
        protected override void Load(ContainerBuilder builder) // override ettiğimiz method
        {

            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope(); // Repository sınıfının generic tipi olarak register ediyoruz.
            builder.RegisterGeneric(typeof(GenericService<>)).As(typeof(IGenericService<>)).InstancePerLifetimeScope(); // Service sınıfının generic tipi olarak register ediyoruz.

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope(); // UnitOfWork sınıfının generic tipi olmadan register ediyoruz. Çünkü UnitOfWork sınıfını generic değil.

            // Assembly'lerin (katmanların) yolunu belirtiyoruz. Burada Assembly.GetExecutingAssembly() metodu ile bulunduğumuz katmanının yolunu alıyoruz.
            // GetAssemblye(typeof()) metodu ile o sınıfın bulunduğu assembly'inin yolunu alıyoruz alıyoruz. Burada hangi sınıfı belirttiğimiz önemli değil. Hangi assembly'i belirttiğimiz önemli.
            var apiAssembly = Assembly.GetExecutingAssembly();
            //  var repoAssembly = Assembly.Load("NLayer.Repository"); // bu şekilde de Assembly ismini alabiliriz ama best practice olanı aşağıdaki gibidir.
            //  var serviceAssembly = Assembly.Load("NLayer.Service");
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
   

            // burada da yolunu belirttiğimiz assembly'leri register et ve bu assembly'lerin içerisinde bulunduğu sınıfların isimlerinin sonu Repository veya Service ile bitenleri ve bu sınıfların miras aldığı intafece'leri al diyoruz.
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly)
              .Where(t => t.Name.EndsWith("Service"))
              .AsImplementedInterfaces()
              .InstancePerLifetimeScope();


        }


    }
}
