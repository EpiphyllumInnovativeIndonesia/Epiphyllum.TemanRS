using System;
using System.Collections.Generic;
using System.Text;
using Epiphyllum.TemanRS.Core.Helpers;

namespace Epiphyllum.TemanRS.Core.Infrastructures.Exceptions
{
    /// <summary>
    /// Represents an api exception
    /// </summary>
    [Serializable]
    public class ApiException : Exception
    {
        /// <summary>
        /// Gets or sets the api exception status code
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the api exception validation errors
        /// </summary>
        public IEnumerable<ValidationError> Errors { get; set; }

        /// <summary>
        /// Gets or sets the api exception reference error code
        /// </summary>
        public string ReferenceErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the api exception reference document link
        /// </summary>
        public string ReferenceDocumentLink { get; set; }

        public ApiException(string message, int statusCode = 500, IEnumerable<ValidationError> errors = null, string errorCode = "", string refLink = "") : base(message)
        {
            StatusCode = statusCode;
            Errors = errors;
            ReferenceErrorCode = errorCode;
            ReferenceDocumentLink = refLink;
        }

        public ApiException(Exception ex, int statusCode = 500) : base(ex.Message)
        {
            StatusCode = statusCode;
        }
    }

}
