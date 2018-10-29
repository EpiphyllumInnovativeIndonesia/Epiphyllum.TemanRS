using System;
using System.Collections.Generic;
using System.Text;

namespace Epiphyllum.TemanRS.Common.Models
{
    public interface IMasterModel : IBaseModel
    {
        bool IsDeleted { get; set; }
        string CreatedBy { get; set; }
        DateTime CreatedTime { get; set; }
        string ModifiedBy { get; set; }
        DateTime? ModifiedTime { get; set; }
    }
}
