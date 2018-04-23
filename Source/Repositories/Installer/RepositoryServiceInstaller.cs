using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Utility.DependencyInjection;

namespace Repositories.Installer
{
    public class RepositoryServiceInstaller : IServicesInstaller
    { 

        public void Install(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>((container, options) =>
            {
                var connStr = container.GetService<IConfiguration>().GetConnectionString("Default");
                options.UseNpgsql(connStr, b => b.MigrationsAssembly("WebApi"));
            });

            services.AddScoped<IDataRepository<Book>, EfRepository<Book>>();
            services.AddScoped<IDataRepository<Customer>, EfRepository<Customer>>();
            services.AddScoped<IDataRepository<Order>, EfRepository<Order>>();
            services.AddScoped<IDataRepository<OrderItem>, EfRepository<OrderItem>>();

        }
    }
}
