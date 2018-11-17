using System;
using System.Collections.Generic;
using System.Text;
using Epiphyllum.TemanRS.Core.Data;

namespace Epiphyllum.TemanRS.Repositories.Domain.Accounts
{
    /// <summary>
    /// Represents a role
    /// </summary>
    public partial class Role : BaseEntity, IAuditable, IConcurrentable
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }

        /// <summary>
        /// Gets or sets the role code
        /// </summary>
        public string RoleCode { get; set; }

        /// <summary>
        /// Gets or sets the role name
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// Gets or sets the role description
        /// </summary>
        public string RoleDescription { get; set; }

        /// <summary>
        /// Gets or sets the role deleted is true or false
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the role created by
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the role created time
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// Gets or sets the role modified by
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the role modified time
        /// </summary>
        public DateTime? ModifiedTime { get; set; }

        /// <summary>
        /// Gets or sets the role row version
        /// </summary>
        public byte[] RowVersion { get; set; }

        /// <summary>
        /// Gets or sets userroles
        /// </summary>
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
