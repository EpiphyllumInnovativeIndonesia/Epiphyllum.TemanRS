using System;
using System.Collections.Generic;
using System.Text;
using Epiphyllum.TemanRS.Common.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Epiphyllum.TemanRS.Common.Infrastructures.DependencyInjection
{
    public class DependencyManagement : IDependencyManagement
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
