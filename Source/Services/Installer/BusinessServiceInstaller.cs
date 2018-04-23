using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Utility.DependencyInjection;

namespace Services.Installer
{
    public class BusinessServiceInstaller : IServicesInstaller
    {
        public void Install(IServiceCollection services)
        {
            services.AddScoped(Classes.FromAssembly(this).BaseOn<IBusinessService>().WithDefaultInterface());

            services.Install(FromAssembly.Contains<IRepositoryService>());
        }
    }
}
