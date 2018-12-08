using System;
using System.Collections.Generic;
using System.Text;
using Epiphyllum.TemanRS.Core.Abstractions;
using Epiphyllum.TemanRS.Core.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Epiphyllum.TemanRS.Core.Tests
{
    public class EngineTests
    {
        private readonly IConfiguration configuration;
        private readonly ServiceCollection services;

        public EngineTests()
        {
            configuration = new ConfigurationBuilder().Build();
            services = new ServiceCollection();
        }

        private void StartEngine()
        {
            var configuration = new ConfigurationBuilder().Build();
            var services = new ServiceCollection();
            var engine = EngineContext.Create();
            engine.Initialize(services);
            engine.ConfigureServices(services, configuration);
        }

        [Fact]
        public void Engine_null_by_default()
        {
            var engine = EngineContext.Current as CoreEngine;

            Assert.Null(engine.ServiceProvider);
        }

        [Fact]
        public void Engine_start_should_not_null()
        {
            var configuration = new ConfigurationBuilder().Build();
            var services = new ServiceCollection();
            var engine = EngineContext.Create();
            engine.Initialize(services);
            engine.ConfigureServices(services, configuration);

            Assert.NotNull(engine);
        }

        [Fact]
        public void Engine_should_resolve_a_service()
        {
            StartEngine();
            IPasswordHasher passwordHasher = EngineContext.Current.Resolve<IPasswordHasher>();
            ICommonHelpers commonHelpers = EngineContext.Current.Resolve<ICommonHelpers>();

            string plainPassword = "Password";
            var hashedPassword = passwordHasher.HashPassword(plainPassword);
            var resultEncoded = commonHelpers.IsBase64Encoded(hashedPassword);
            var resultVerifyPassword = passwordHasher.VerifyHashedPassword(hashedPassword, "Password");

            Assert.True(resultEncoded);
            Assert.Equal(PasswordVerificationStatus.Success, resultVerifyPassword);
        }
    }
}
