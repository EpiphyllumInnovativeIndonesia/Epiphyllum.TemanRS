using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Epiphyllum.TemanRS.Core.Providers;
using Epiphyllum.TemanRS.Integration.Tests.Fake;
using Epiphyllum.TemanRS.Repositories;
using Epiphyllum.TemanRS.Services.Models;
using Newtonsoft.Json;
using Xunit;

namespace Epiphyllum.TemanRS.Integration.Tests
{
    public class AuthenticationTests
    {
        [Fact]
        public async Task Login_status_should_be_ok()
        {
            using (var client = new ClientProvider().Client)
            {
                var request = new
                {
                    Username = "Superadmin",
                    Password = "superadmin"
                };
                var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

                var response = await client.PostAsync("/login", content);

                var responseBody = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<ApiResponse<Authentication>>(responseBody);
                var authentication = responseObject.Result;

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.Equal(request.Username, authentication.Username);
            }
        }

        [Fact]
        public async Task Login_status_should_not_be_ok()
        {
            using (var client = new ClientProvider().Client)
            {
                var request = new
                {
                    Username = "Superadmin",
                    Password = "Superadmin"
                };
                var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

                var response = await client.PostAsync("/login", content);

                var responseBody = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<ApiResponse<object>>(responseBody);
                var exception = responseObject.ResponseException;

                Assert.NotEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public async Task Current_status_should_be_ok()
        {
            using (var client = new ClientProvider().Client)
            {
                var request = new
                {
                    Username = "Superadmin",
                    Password = "superadmin"
                };
                var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

                var response = await client.PostAsync("/login", content);

                var responseBody = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<Authentication>>(responseBody);
                var authentication = apiResponse.Result;

                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authentication.Token);
                var result = await client.GetAsync("/current");

                var resultBody = await result.Content.ReadAsStringAsync();
                var apiResult = JsonConvert.DeserializeObject<ApiResponse<UserManager>>(resultBody);
                var userManager = apiResult.Result;

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.Equal(request.Username, userManager.Username);
            }
        }
    }
}
