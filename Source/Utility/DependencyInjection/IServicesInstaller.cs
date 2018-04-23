using Microsoft.Extensions.DependencyInjection;

namespace Utility.DependencyInjection
{
    public interface IServicesInstaller
    {
        void Install(IServiceCollection services);
    }
}
