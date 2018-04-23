using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace Utility.DependencyInjection
{
    public static class ServiceCollectionInstaller
    {
        public static void Install(this IServiceCollection serviceCollection, List<IServicesInstaller> installers)
        {
            installers.ForEach(i => i.Install(serviceCollection));
        }

        public static void AddScoped(this IServiceCollection services, List<ServiceReference> servicePairs)
        {
            servicePairs.ForEach(s => services.AddScoped(s.Service, s.Implementation));
        }
    }
}
