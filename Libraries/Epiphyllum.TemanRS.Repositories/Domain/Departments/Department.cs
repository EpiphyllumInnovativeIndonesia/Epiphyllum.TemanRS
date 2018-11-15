using System;
using System.Collections.Generic;
using System.Text;

namespace Epiphyllum.TemanRS.Repositories.Domain.Departments
{
    /// <summary>
    /// Represents a department
    /// </summary>
    public partial class Department : BaseEntity, IAuditable, IConcurrentable
    {
        /// <summary>
        /// Gets or sets the department code
        /// </summary>
        public string DepartmentCode { get; set; }

        /// <summary>
        /// Gets or sets the department name
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// Gets or sets the department description
        /// </summary>
        public string DepartmentDescription { get; set; }

        /// <summary>
        /// Gets or sets the entity deleted is true or false
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the entity created by
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the entity created time
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// Gets or sets the entity modified by
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the entity modified time
        /// </summary>
        public DateTime? ModifiedTime { get; set; }

        /// <summary>
        /// Gets or sets the entity row version
        /// </summary>
        public byte[] RowVersion { get; set; }
    }
}
