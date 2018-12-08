using Microsoft.Extensions.DependencyInjection;

namespace Epiphyllum.TemanRS.Core.Abstractions
{
    public partial interface IDependencyRegistrar
    {
        IServiceCollection ConfigureDependency(IServiceCollection services);
    }
}
