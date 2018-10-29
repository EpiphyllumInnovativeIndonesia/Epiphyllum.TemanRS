using System;
using System.Collections.Generic;
using System.Text;

namespace Epiphyllum.TemanRS.Common.Models
{
    public interface IHistoryModel : IBaseModel
    {
        string CreatedBy { get; set; }
        DateTime CreatedTime { get; set; }
    }
}
