using System;
using System.Collections.Generic;
using System.Text;

namespace Epiphyllum.TemanRS.Repositories.Domain
{
    /// <summary>
    /// Interface for auditable entities
    /// </summary>
    public interface IAuditable
    {

        /// <summary>
        /// Gets or sets the entity deleted is true or false
        /// </summary>
        bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the entity created by
        /// </summary>
        string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the entity created time
        /// </summary>
        DateTime CreatedTime { get; set; }

        /// <summary>
        /// Gets or sets the entity modified by
        /// </summary>
        string ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the entity modified time
        /// </summary>
        DateTime? ModifiedTime { get; set; }
    }
}
