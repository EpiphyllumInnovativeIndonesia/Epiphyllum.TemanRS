using System;
using System.Text;
using Epiphyllum.TemanRS.Core.Helpers;
using Xunit;

namespace Epiphyllum.TemanRS.Core.Tests.Helpers
{
    public class CommonHelpersTests
    {
        private readonly CommonHelpers commonHelpers;

        public CommonHelpersTests()
        {
            commonHelpers = new CommonHelpers();
        }

        [Fact]
        public void Should_check_whether_string_is_encoded64string()
        {
            string encodedString = Convert.ToBase64String(Encoding.UTF8.GetBytes("MyString#"));
            var result = commonHelpers.IsBase64Encoded(encodedString);

            Assert.True(result);
        }

        [Fact]
        public void Should_check_whether_string_is_not_encoded64string()
        {
            string encodedString = "MyString#";
            var result = commonHelpers.IsBase64Encoded(encodedString);

            Assert.False(result);
        }
    }
}
