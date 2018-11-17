using System;
using System.Collections.Generic;
using System.Text;

namespace Epiphyllum.TemanRS.Core.Data
{
    /// <summary>
    /// Interface for concurrentable entities
    /// </summary>
    public interface IConcurrentable
    {
        /// <summary>
        /// Gets or sets the entity row version
        /// </summary>
        byte[] RowVersion { get; set; }
    }
}
