using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Epiphyllum.TemanRS.Core.Enums
{
    /// <summary>
    /// Represents an api response status enum
    /// </summary>
    public enum ApiResponseStatus
    {
        /// <summary>
        /// Represents an api response status was successful
        /// </summary>
        [Description("Request successful.")]
        Success,

        /// <summary>
        /// Represents an api response status was responded with exceptions
        /// </summary>
        [Description("Request responded with exceptions.")]
        Exception,

        /// <summary>
        /// Represents an api response status was denied
        /// </summary>
        [Description("Request denied.")]
        UnAuthorized,

        /// <summary>
        /// Represents an api response status was responded with validation errors
        /// </summary>
        [Description("Request responded with validation error(s).")]
        ValidationError,

        /// <summary>
        /// Represents an api response status was failure
        /// </summary>
        [Description("Unable to process the request.")]
        Failure

    }
}
