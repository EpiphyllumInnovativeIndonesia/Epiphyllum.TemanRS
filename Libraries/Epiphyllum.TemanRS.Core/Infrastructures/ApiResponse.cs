﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using Epiphyllum.TemanRS.Core.Helpers;
using Newtonsoft.Json;

namespace Epiphyllum.TemanRS.Core.Infrastructures
{
    /// <summary>
    /// Represents an api response
    /// </summary>
    [DataContract]
    public class ApiResponse
    {
        /// <summary>
        /// Gets the api response version
        /// </summary>
        [DataMember]
        public string Version
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.Major.ToString() + '.' +
                       Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString();
            }
        }

        /// <summary>
        /// Gets or sets the api response status code
        /// </summary>
        [DataMember]
        public int StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the api response is success
        /// </summary>
        [DataMember]
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Gets or sets the api response message
        /// </summary>
        [DataMember]
        public List<string> Message { get; set; }

        /// <summary>
        /// Gets or sets the api response exception
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public ApiError ResponseException { get; set; }

        /// <summary>
        /// Gets or sets the api response result
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public object Result { get; set; }

        [JsonConstructor]
        public ApiResponse(int statusCode, List<string> message = null, object result = null, ApiError apiError = null)
        {
            StatusCode = statusCode;
            IsSuccess = apiError == null;
            Message = message;
            Result = result;
            ResponseException = apiError;
        }
    }

}