using System;
using System.Collections.Generic;
using System.Text;

namespace Epiphyllum.TemanRS.Repositories.Data.Mapping
{
    /// <summary>
    /// Represents default values related to data mapping
    /// </summary>
    public static class MappingDefault
    {
        /// <summary>
        /// Gets a name of the unique index column
        /// </summary>
        public static string UniqueIndex => "UIX_{0}_{1}";
    }
}
