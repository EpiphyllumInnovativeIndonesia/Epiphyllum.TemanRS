using System;
using System.Collections.Generic;
using System.Text;
using Epiphyllum.TemanRS.Core.Helpers;
using Epiphyllum.TemanRS.Unit.Tests.Fake;
using Xunit;

namespace Epiphyllum.TemanRS.Unit.Tests.Helpers
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
