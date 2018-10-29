using System;
using System.Collections.Generic;

namespace Epiphyllum.TemanRS.Models
{
    public partial class Menu
    {
        public Menu()
        {
            InverseParent = new HashSet<Menu>();
            RoleMenu = new HashSet<RoleMenu>();
        }

        public int Id { get; set; }
        public string MenuCode { get; set; }
        public string MenuName { get; set; }
        public string MenuDescription { get; set; }
        public string MenuController { get; set; }
        public int? ParentId { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public byte[] RowVersion { get; set; }

        public Menu Parent { get; set; }
        public ICollection<Menu> InverseParent { get; set; }
        public ICollection<RoleMenu> RoleMenu { get; set; }
    }
}
