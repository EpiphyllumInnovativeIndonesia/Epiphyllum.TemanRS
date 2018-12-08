using Epiphyllum.TemanRS.Core.Providers;

namespace Epiphyllum.TemanRS.Core.Tests.Fake
{
    public class FakeProviders
    {
        public static ConnectionStrings GetConnectionStrings() => new ConnectionStrings
        {
            Default = "FakeDefaultConnectionStrings"
        };

        public static CultureInfo GetCultureInfo() => new CultureInfo
        {
            Default = "FakeDefaultCultureInfo",
            DefaultUI = "FakeDefaultUICultureInfo"
        };

        public static EpiphyllumConfig GetEpiphyllumConfig() => new EpiphyllumConfig
        {
            ConnectionStrings = GetConnectionStrings()
        };

        public static JwtAuthentication GetJwtAuthentication() => new JwtAuthentication
        {
            Key = "FakeJwtAuthenticationKey",
            Expires = 666
        };
    }
}
