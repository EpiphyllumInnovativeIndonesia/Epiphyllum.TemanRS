namespace Epiphyllum.TemanRS.Core.Providers
{
    /// <summary>
    /// Represents a jwt authentication
    /// </summary>
    public partial class JwtAuthentication
    {
        /// <summary>
        /// Gets or sets the jwt authentication key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the jwt authentication expires
        /// </summary>
        public int Expires { get; set; }
    }
}
