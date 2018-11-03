using System;

namespace Epiphyllum.TemanRS.Common.Models
{
    /// <summary>
    /// Master model interface inherit from base model interface.
    /// </summary>
    public interface IMasterModel : IBaseModel
    {
        bool IsDeleted { get; set; }
        string CreatedBy { get; set; }
        DateTime CreatedTime { get; set; }
        string ModifiedBy { get; set; }
        DateTime? ModifiedTime { get; set; }
    }
}
