using System;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Utility.DependencyInjection;

namespace WebApi
{
    public static class ApplicationBoot
    {
        private static ServiceProvider _serviceProvider;

        private static Action<IServiceCollection> _testingServicesRegistrar;

        private static Action<IServiceProvider> _testingServicesRegister;

        public static IServiceProvider ServiceProvider => _serviceProvider;

        public static void AddTestingServicesRegistrar(Action<IServiceCollection> registrar)
        {
            _testingServicesRegistrar = registrar;
        }

        public static void RegisterServices(IServiceCollection services)
        {
            RegisterCommonServices(services);
        }

        public static void RegisterServicesForTesting(IServiceCollection service)
        {
            RegisterCommonServices(service);

            _testingServicesRegistrar?.Invoke(service);
        }

        private static void RegisterCommonServices(IServiceCollection services)
        {
            services.Install(FromAssembly.This());
            services.Install(FromAssembly.Contains<IBusinessService>());
        }
    }
}
