using System;
using System.Collections.Generic;
using System.Text;

namespace Epiphyllum.TemanRS.Repositories.Domain.Accounts
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
        /// Gets or sets the authentication roles
        /// </summary>
        public IEnumerable<Role> Roles { get; set; }
    }
}
