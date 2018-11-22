using System;
using System.Collections.Generic;
using System.Text;

namespace Epiphyllum.TemanRS.Core.Configuration
{
    /// <summary>
    /// Represents a culture info
    /// </summary>
    public partial class CultureInfo
    {
        /// <summary>
        /// Gets or sets the default culture info
        /// </summary>
        public string Default { get; set; }

        /// <summary>
        /// Gets or sets the default UI culture info
        /// </summary>
        public string DefaultUI { get; set; }
    }
}
