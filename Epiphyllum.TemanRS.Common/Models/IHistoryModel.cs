using System;

namespace Epiphyllum.TemanRS.Common.Models
{
    /// <summary>
    /// History model interface inherit from base model interface.
    /// </summary>
    public interface IHistoryModel : IBaseModel
    {
        string CreatedBy { get; set; }
        DateTime CreatedTime { get; set; }
    }
}
