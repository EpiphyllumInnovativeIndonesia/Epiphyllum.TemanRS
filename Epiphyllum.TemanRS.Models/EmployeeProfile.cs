using System;
using System.Collections.Generic;

namespace Epiphyllum.TemanRS.Models
{
    public partial class EmployeeProfile
    {
        public EmployeeProfile()
        {
            EmployeeAddress = new HashSet<EmployeeAddress>();
        }

        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string IdentityNo { get; set; }
        public string Photo { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Religion { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Occupation { get; set; }
        public string Nationality { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public byte[] RowVersion { get; set; }

        public Employee Employee { get; set; }
        public ICollection<EmployeeAddress> EmployeeAddress { get; set; }
    }
}
