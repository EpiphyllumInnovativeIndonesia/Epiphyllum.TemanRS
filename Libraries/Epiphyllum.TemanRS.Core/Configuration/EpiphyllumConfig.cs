using System;
using System.Collections.Generic;
using System.Text;

namespace Epiphyllum.TemanRS.Core.Configuration
{
    /// <summary>
    /// Represents startup epiphyllum configuration parameters
    /// </summary>
    public class EpiphyllumConfig
    {
        /// <summary>
        /// Gets or sets the epiphyllum connection strings
        /// </summary>
        public ConnectionStrings ConnectionStrings { get; set; }

        /// <summary>
        /// Gets or sets the epiphyllum jwt authentication
        /// </summary>
        public JwtAuthentication JwtAuthentication { get; set; }
    }
}
