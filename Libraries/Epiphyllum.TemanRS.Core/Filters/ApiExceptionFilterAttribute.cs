using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Epiphyllum.TemanRS.Core.Helpers;
using Epiphyllum.TemanRS.Core.Infrastructures;
using Epiphyllum.TemanRS.Core.Infrastructures.Exceptions;
using Epiphyllum.TemanRS.Core.Localization.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;

namespace Epiphyllum.TemanRS.Core.Filters
{
    /// <summary>
    /// Represents an api exception filter attribute
    /// </summary>
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute, IAsyncExceptionFilter
    {
        private readonly IStringLocalizer<ApiResponseMessage> _stringLocalizer;

        public ApiExceptionFilterAttribute(IStringLocalizer<ApiResponseMessage> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }

        /// <summary>
        /// Handling response if request got an exception
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            await base.OnExceptionAsync(context);

            ApiError apiError;
            ApiResponse apiResponse;
            List<string> apiMessage = new List<string>();
            int code = 0;
            string responseMessage = string.Empty;

            if (context.Exception is ApiException)
            {
                var ex = context.Exception as ApiException;
                apiError = new ApiError(ex.Message);
                apiError.ValidationErrors = ex.Errors;
                apiError.ReferenceErrorCode = ex.ReferenceErrorCode;
                apiError.ReferenceDocumentLink = ex.ReferenceDocumentLink;
                code = ex.StatusCode;

            }
            else if (context.Exception is UnauthorizedAccessException)
            {
                responseMessage = _stringLocalizer[ApiResponseMessage.Unauthorized];
                apiError = new ApiError(responseMessage);
                code = (int)HttpStatusCode.Unauthorized;
            }
            else
            {
#if !DEBUG
                var msg = _stringLocalizer[ApiResponseMessage.Unhandled];
                string stack = null;
#else
                var msg = context.Exception.GetBaseException().Message;
                string stack = context.Exception.StackTrace;
#endif

                apiError = new ApiError(msg);
                apiError.Details = stack;
                code = (int)HttpStatusCode.InternalServerError;

            }

            responseMessage = _stringLocalizer[ApiResponseMessage.Exception];
            apiMessage.Add(responseMessage);
            apiResponse = new ApiResponse(code, apiMessage, null, apiError);

            context.HttpContext.Response.StatusCode = code;
            context.Result = new JsonResult(apiResponse);
        }
    }
}
