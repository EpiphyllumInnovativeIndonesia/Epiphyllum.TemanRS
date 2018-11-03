namespace Epiphyllum.TemanRS.Common.Configuration
{
    /// <summary>
    /// Connection strings class.
    /// </summary>
    public class ConnectionStrings
    {
        /// <summary>
        /// Get default connection strings.
        /// </summary>
        public string Default { get; set; }

        /// <summary>
        /// Get master database connection strings.
        /// </summary>
        public string Master { get; set; }

        /// <summary>
        /// Get transaction database connection strings.
        /// </summary>
        public string Transaction { get; set; }
    }
}
