using System;
using System.Collections.Generic;
using System.Text;
using Epiphyllum.TemanRS.Common.Data;

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
        /// Gets or sets the department deleted is true or false
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the department created by
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the department created time
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// Gets or sets the department modified by
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the department modified time
        /// </summary>
        public DateTime? ModifiedTime { get; set; }

        /// <summary>
        /// Gets or sets the department row version
        /// </summary>
        public byte[] RowVersion { get; set; }
    }
}
