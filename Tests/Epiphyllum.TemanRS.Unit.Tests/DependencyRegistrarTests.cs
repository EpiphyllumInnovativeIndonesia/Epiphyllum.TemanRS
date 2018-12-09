using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Epiphyllum.TemanRS.Unit.Tests
{
    public class DependencyRegistrarTests
    {
        public interface IFoo { }
        public class Foo : IFoo { }
        public class Foo2 : IFoo { }
        public class Foo3 : IFoo { }

        [Fact]
        public void Should_register_dependency_as_self_with_interfaces()
        {
            var services = new ServiceCollection();
            services.Scan(scan => scan.FromApplicationDependencies()
                .AddClasses(classes => classes.AssignableTo<IFoo>())
                    .AsSelfWithInterfaces()
                    .WithSingletonLifetime());

            var serviceProvider = services.BuildServiceProvider();
            var arrayFoo = serviceProvider.GetRequiredService<IEnumerable<IFoo>>();

            Assert.Equal(3, arrayFoo.Count());
            Assert.Equal(typeof(Foo), arrayFoo.Single(prop => prop.GetType().Equals(typeof(Foo))).GetType());
            Assert.Equal(typeof(Foo2), arrayFoo.Single(prop => prop.GetType().Equals(typeof(Foo2))).GetType());
            Assert.Equal(typeof(Foo3), arrayFoo.Single(prop => prop.GetType().Equals(typeof(Foo3))).GetType());
        }

        [Fact]
        public void Should_register_dependency_as_matching_interface()
        {
            var services = new ServiceCollection();
            services.Scan(scan => scan.FromApplicationDependencies()
                .AddClasses(classes => classes.AssignableTo<IFoo>())
                    .AsMatchingInterface()
                    .WithSingletonLifetime());

            var serviceProvider = services.BuildServiceProvider();
            var arrayFoo = serviceProvider.GetRequiredService<IEnumerable<IFoo>>();

            Assert.Single(arrayFoo);
            Assert.Equal(typeof(Foo), arrayFoo.Single().GetType());
            Assert.NotEqual(typeof(Foo2), arrayFoo.Single().GetType());
            Assert.NotEqual(typeof(Foo3), arrayFoo.Single().GetType());
        }
    }
}
