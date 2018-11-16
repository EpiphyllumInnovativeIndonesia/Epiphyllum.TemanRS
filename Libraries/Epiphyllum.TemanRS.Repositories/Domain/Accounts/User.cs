using System;
using System.Collections.Generic;
using System.Text;

namespace Epiphyllum.TemanRS.Repositories.Domain.Accounts
{
    /// <summary>
    /// Represents an user
    /// </summary>
    public partial class User : BaseEntity, IAuditable, IConcurrentable
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }

        /// <summary>
        /// Gets or sets the user username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the user password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the user deleted is true or false
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the user created by
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the user created time
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// Gets or sets the user modified by
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the user modified time
        /// </summary>
        public DateTime? ModifiedTime { get; set; }

        /// <summary>
        /// Gets or sets the user row version
        /// </summary>
        public byte[] RowVersion { get; set; }

        /// <summary>
        /// Gets or sets userroles
        /// </summary>
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
