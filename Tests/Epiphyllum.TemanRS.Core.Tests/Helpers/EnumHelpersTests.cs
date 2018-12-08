using System;
using System.Collections.Generic;
using System.Text;
using Epiphyllum.TemanRS.Core.Helpers;
using Epiphyllum.TemanRS.Core.Tests.Fake;
using Xunit;

namespace Epiphyllum.TemanRS.Core.Tests.Helpers
{
    public class EnumHelpersTests
    {
        [Fact]
        public void Should_get_enum_description()
        {
            var result = FakeEnum.One.GetDescription();
            Assert.Equal("One Fake Enum", result);

            result = FakeEnum.Two.GetDescription();
            Assert.Equal("Two Fake Enum", result);
        }
    }
}
