using System;

namespace Epiphyllum.TemanRS.Core.Abstractions
{
    /// <summary>
    /// Interface for auditable entities
    /// </summary>
    public partial interface IAuditable
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
