using System;
using System.Collections.Generic;

namespace Epiphyllum.TemanRS.Models
{
    public partial class User
    {
        public User()
        {
            Employee = new HashSet<Employee>();
            UserRole = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public byte[] RowVersion { get; set; }

        public ICollection<Employee> Employee { get; set; }
        public ICollection<UserRole> UserRole { get; set; }
    }
}
