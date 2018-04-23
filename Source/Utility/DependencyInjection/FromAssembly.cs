using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Utility.DependencyInjection
{
    public class FromAssembly
    {
        public static List<IServicesInstaller> Contains<T>()
        {
            var assembly = typeof(T).GetTypeInfo().Assembly;

            return ScanInstallers(assembly);
        }

        public static List<IServicesInstaller> Contains<T>(IConfiguration configuration)
        {
            var assembly = typeof(T).GetTypeInfo().Assembly;

            return ScanInstallers(assembly, configuration);
        }

        public static List<IServicesInstaller> This()
        {
            var assembly = Assembly.GetEntryAssembly();

            return ScanInstallers(assembly);
        }

        private static List<IServicesInstaller> ScanInstallers(Assembly assembly)
        {
            var installers = assembly.ExportedTypes
                .Where(t => typeof(IServicesInstaller).IsAssignableFrom(t))
                .Where(t => t.IsClass)
                .Select(Activator.CreateInstance)
                .Select(i => i as IServicesInstaller)
                .ToList();

            return installers;
        }

        private static List<IServicesInstaller> ScanInstallers(Assembly assembly, params object[] args)
        {
            var installers = assembly.ExportedTypes
                .Where(t => typeof(IServicesInstaller).IsAssignableFrom(t))
                .Where(t => t.IsClass)
                .Select(t => Activator.CreateInstance(t, args))
                .Select(i => i as IServicesInstaller)
                .ToList();

            return installers;
        }
    }
}
