using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Epiphyllum.TemanRS.Core;
using Epiphyllum.TemanRS.Core.Localization.Resources;
using Epiphyllum.TemanRS.Core.Providers;
using Epiphyllum.TemanRS.Web.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Localization;
using Xunit;

namespace Epiphyllum.TemanRS.Integration.Tests.Fake
{
    public class ClientProvider : IDisposable
    {
        private TestServer server;

        public HttpClient Client => server.CreateClient();

        public ClientProvider()
        {
            server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
        }

        public void Dispose()
        {
            server?.Dispose();
            Client?.Dispose();
        }

        [Fact]
        public async Task Index_status_should_be_ok()
        {
            using (var client = new ClientProvider().Client)
            {
                var response = await client.GetAsync("/");
                response.EnsureSuccessStatusCode();

                var localizer = EngineContext.Current.Resolve<IStringLocalizer<Message>>();
                var responseBody = await response.Content.ReadAsStringAsync();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.Equal(localizer[Message.Hello], responseBody);
            }
        }
    }
}
