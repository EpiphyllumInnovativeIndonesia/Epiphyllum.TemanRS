using System;
using System.Collections.Generic;

namespace Epiphyllum.TemanRS.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeProfile = new HashSet<EmployeeProfile>();
        }

        public int Id { get; set; }
        public string EmployeeNo { get; set; }
        public int DepartmentId { get; set; }
        public int? UserId { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public byte[] RowVersion { get; set; }

        public Department Department { get; set; }
        public User User { get; set; }
        public ICollection<EmployeeProfile> EmployeeProfile { get; set; }
    }
}
