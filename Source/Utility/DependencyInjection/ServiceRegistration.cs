using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Utility.DependencyInjection
{
    public static class Classes
    {
        public static ThisAssemblyReference FromAssembly(object obj)
        {
            return new ThisAssemblyReference(obj.GetType());
        }

        public class ThisAssemblyReference
        {
            private readonly Type _type;

            public ThisAssemblyReference(Type type)
            {
                _type = type;
            }

            public Services<T> BaseOn<T>()
            {
                if (!typeof(T).GetTypeInfo().IsInterface)
                {
                    throw new ArgumentException("T must be a interface");
                }

                return new Services<T>(_type);
            }

        }

        public class Services<T>
        {
            private readonly Type _type;

            public Services(Type type)
            {
                _type = type;
            }

            public List<ServiceReference> WithDefaultInterface()
            {
                var serviceWithImpl = _type.Assembly.ExportedTypes
                    .Where(t => typeof(T).IsAssignableFrom(t))
                    .Where(t => t.IsClass)
                    .Select(t => new ServiceReference() { Implementation = t, Service = GetDefaultInterface(t) })
                    .ToList();

                return serviceWithImpl;
            }

            private Type GetDefaultInterface(Type type)
            {
                var i = type.GetInterfaces().First();

                return i;
            }
        }
    }

    public class ServiceReference
    {
        public Type Service { get; set; }

        public Type Implementation { get; set; }
    }
}
