using System;
using System.Collections.Generic;
using System.Text;

namespace Epiphyllum.TemanRS.Core.Configuration
{
    /// <summary>
    /// Represents a jwt authentication
    /// </summary>
    public class JwtAuthentication
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
