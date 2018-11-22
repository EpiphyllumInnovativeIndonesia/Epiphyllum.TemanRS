using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Epiphyllum.TemanRS.Core.Helpers
{
    /// <summary>
    /// Represents a validation error
    /// </summary>
    public partial class ValidationError
    {
        /// <summary>
        /// Gets the validation error field
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Field { get; }

        /// <summary>
        /// Gets the validation error message
        /// </summary>
        public string Message { get; }

        public ValidationError(string field, string message)
        {
            Field = field != string.Empty ? field : null;
            Message = message;
        }
    }

}
