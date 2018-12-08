using Epiphyllum.TemanRS.Core.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Epiphyllum.TemanRS.Core
{
    public partial class DependencyRegistrar : IDependencyRegistrar
    {
        public IServiceCollection ConfigureDependency(IServiceCollection services)
        {
            services.Scan(scan => scan.FromApplicationDependencies()
                .AddClasses(classes => classes.AssignableTo<IRegisterSingleton>())
                    .AsSelfWithInterfaces()
                    .WithSingletonLifetime()
                .AddClasses(classes => classes.AssignableTo<IRegisterScoped>())
                    .AsSelfWithInterfaces()
                    .WithScopedLifetime()
                .AddClasses(classes => classes.AssignableTo<IRegisterTransient>())
                    .AsSelfWithInterfaces()
                    .WithTransientLifetime()
                .AddClasses(classes => classes.AssignableTo(typeof(IRepository<>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

            return services;
        }
    }
}
