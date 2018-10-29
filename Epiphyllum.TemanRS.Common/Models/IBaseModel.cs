using System;
using System.Collections.Generic;
using System.Text;

namespace Epiphyllum.TemanRS.Common.Models
{
    public interface IBaseModel
    {
        int Id { get; set; }
        byte[] RowVersion { get; set; }
    }
}
