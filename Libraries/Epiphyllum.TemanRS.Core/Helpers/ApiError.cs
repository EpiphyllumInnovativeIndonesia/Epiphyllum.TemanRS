using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace Epiphyllum.TemanRS.Core.Helpers
{
    /// <summary>
    /// Represents an api error
    /// </summary>
    public class ApiError
    {
        /// <summary>
        /// Gets or sets the api error is error
        /// </summary>
        public bool IsError { get; set; }

        /// <summary>
        /// Gets or sets the api error exception message
        /// </summary>
        public string ExceptionMessage { get; set; }

        /// <summary>
        /// Gets or sets the api error details
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// Gets or sets the api error reference error code
        /// </summary>
        public string ReferenceErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the api error reference document link
        /// </summary>
        public string ReferenceDocumentLink { get; set; }

        /// <summary>
        /// Gets or sets the api error validation errors
        /// </summary>
        public IEnumerable<ValidationError> ValidationErrors { get; set; }

        [JsonConstructor]
        public ApiError(string message)
        {
            ExceptionMessage = message;
            IsError = true;
        }

        public ApiError(string message, string details)
        {
            ExceptionMessage = message;
            Details = details;
            IsError = true;
        }

        public ApiError(ModelStateDictionary modelState)
        {
            IsError = true;
            if (modelState != null && modelState.Any(m => m.Value.Errors.Count > 0))
            {
                ExceptionMessage = "Please correct the specified validation errors and try again.";
                ValidationErrors = modelState.Keys
                    .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
                    .ToList();

            }
        }

    }
}
