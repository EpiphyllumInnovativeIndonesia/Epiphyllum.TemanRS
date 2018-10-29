using System;
using System.Collections.Generic;

namespace Epiphyllum.TemanRS.Models
{
    public partial class MasterDocumentHistory
    {
        public int Id { get; set; }
        public string Section { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
