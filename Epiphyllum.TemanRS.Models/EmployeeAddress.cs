using System;
using System.Collections.Generic;

namespace Epiphyllum.TemanRS.Models
{
    public partial class EmployeeAddress
    {
        public int Id { get; set; }
        public int EmployeeProfileId { get; set; }
        public string Street { get; set; }
        public string Village { get; set; }
        public string SubDistrict { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public byte[] RowVersion { get; set; }

        public EmployeeProfile EmployeeProfile { get; set; }
    }
}
