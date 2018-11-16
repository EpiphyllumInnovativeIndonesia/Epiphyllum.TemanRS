﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Epiphyllum.TemanRS.Common.Enums
{
    /// <summary>
    /// Represents a password verification status enum
    /// </summary>
    public enum PasswordVerificationStatus
    {
        /// <summary>
        /// Represents a password verification was failed
        /// </summary>
        Failed = 0,

        /// <summary>
        /// Represents a password verification was success
        /// </summary>
        Success = 1,

        /// <summary>
        /// Represents a password verification was success but rehash is needed
        /// </summary>
        SuccessRehashNeeded = 2
    }
}