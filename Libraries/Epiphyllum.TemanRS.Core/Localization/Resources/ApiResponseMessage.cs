using System;
using System.Collections.Generic;
using System.Text;
using Epiphyllum.TemanRS.Core.Enums;

namespace Epiphyllum.TemanRS.Core.Localization.Resources
{
    /// <summary>
    /// Represents an api response message
    /// </summary>
    public class ApiResponseMessage
    {
        public const string Success = "Success";
        public const string Exception = "Exception";
        public const string Unauthorized = "Unauthorized";
        public const string ValidationError = "ValidationError";
        public const string Failure = "Failure";
        public const string NotFound = "NotFound";
        public const string ContactSupport = "ContactSupport";
    }
}
