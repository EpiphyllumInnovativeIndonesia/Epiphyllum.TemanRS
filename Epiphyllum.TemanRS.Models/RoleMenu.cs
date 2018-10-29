using System;
using System.Collections.Generic;

namespace Epiphyllum.TemanRS.Models
{
    public partial class RoleMenu
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int MenuId { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public byte[] RowVersion { get; set; }

        public Menu Menu { get; set; }
        public Role Role { get; set; }
    }
}
