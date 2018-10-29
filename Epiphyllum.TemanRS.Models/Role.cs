using System;
using System.Collections.Generic;

namespace Epiphyllum.TemanRS.Models
{
    public partial class Role
    {
        public Role()
        {
            RoleMenu = new HashSet<RoleMenu>();
            UserRole = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string RoleCode { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public byte[] RowVersion { get; set; }

        public ICollection<RoleMenu> RoleMenu { get; set; }
        public ICollection<UserRole> UserRole { get; set; }
    }
}
