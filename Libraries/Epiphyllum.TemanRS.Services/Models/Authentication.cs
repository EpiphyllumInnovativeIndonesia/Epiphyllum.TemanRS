using System.Collections.Generic;

namespace Epiphyllum.TemanRS.Services.Models
{
    /// <summary>
    /// Represents an authentication entity
    /// </summary>
    public partial class Authentication
    {
        /// <summary>
        /// Gets or sets the authentication username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the authentication token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the authentication token expires
        /// </summary>
        public int TokenExpires { get; set; }

        /// <summary>
        /// Gets or sets the authentication roles
        /// </summary>
        public IEnumerable<string> Roles { get; set; }
    }
}
