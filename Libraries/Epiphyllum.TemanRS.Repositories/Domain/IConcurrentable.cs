﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Epiphyllum.TemanRS.Repositories.Domain
{
    /// <summary>
    /// Interface for concurrentable entities
    /// </summary>
    public interface IConcurrentable
    {
        /// <summary>
        /// Gets or sets the entity row version
        /// </summary>
        byte[] RowVersion { get; set; }
    }
}
