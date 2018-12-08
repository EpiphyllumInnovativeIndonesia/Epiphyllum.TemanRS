using System;
using System.Collections.Generic;
using System.Text;
using Epiphyllum.TemanRS.Core.Helpers;
using Epiphyllum.TemanRS.Core.Tests.Fake;
using Newtonsoft.Json;
using Xunit;

namespace Epiphyllum.TemanRS.Core.Tests.Helpers
{
    public class JsonHelpersTests
    {
        [Fact]
        public void Should_check_whether_string_is_valid_json()
        {
            var anonyObject = new
            {
                ConnectionStrings = new object[] {
                    FakeProviders.GetConnectionStrings(),
                    FakeProviders.GetConnectionStrings()
                },
                CultureInfo = FakeProviders.GetCultureInfo(),
                JwtAuthentication = FakeProviders.GetJwtAuthentication()
            };

            string serializedObject = JsonConvert.SerializeObject(anonyObject);
            var result = JsonHelpers.IsValidJson(serializedObject);

            Assert.True(result);
        }

        [Fact]
        public void Should_check_whether_string_is_not_valid_json()
        {
            string serializedObject = "serialized json object";
            var result = JsonHelpers.IsValidJson(serializedObject);

            Assert.False(result);
        }
    }
}
