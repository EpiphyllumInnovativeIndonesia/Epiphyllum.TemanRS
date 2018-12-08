using System;
using Epiphyllum.TemanRS.Core.Abstractions;

namespace Epiphyllum.TemanRS.Repositories.Entity
{
    /// <summary>
    /// Represents an user role mapping
    /// </summary>
    public partial class UserRole : BaseEntity, IAuditable, IConcurrentable
    {
        /// <summary>
        /// Gets or sets the user identifier
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the role identifier
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or sets the user
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the role
        /// </summary>
        public Role Role { get; set; }

        /// <summary>
        /// Gets or sets the user role deleted is true or false
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the user role created by
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the user role created time
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// Gets or sets the user role modified by
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the user role modified time
        /// </summary>
        public DateTime? ModifiedTime { get; set; }

        /// <summary>
        /// Gets or sets the user role row version
        /// </summary>
        public byte[] RowVersion { get; set; }
    }
}
