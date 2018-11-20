using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Epiphyllum.TemanRS.Core.Enums;
using Epiphyllum.TemanRS.Core.Helpers;
using Epiphyllum.TemanRS.Core.Infrastructures.Exceptions;
using Epiphyllum.TemanRS.Core.Localization.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;

namespace Epiphyllum.TemanRS.Core.Infrastructures.Middleware
{
    /// <summary>
    /// Represents an api response middleware
    /// </summary>
    public class ApiResponseMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IStringLocalizer<ApiResponseMessage> _stringLocalizer;

        public ApiResponseMiddleware(RequestDelegate next, IStringLocalizer<ApiResponseMessage> stringLocalizer)
        {
            _next = next;
            _stringLocalizer = stringLocalizer;
        }

        /// <summary>
        /// Invoking the api response middleware
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                if (IsSwagger(context))
                {
                    await _next(context);
                }
                else
                {
                    var originalBodyStream = context.Response.Body;

                    using (var responseBody = new MemoryStream())
                    {
                        context.Response.Body = responseBody;

                        try
                        {
                            await _next.Invoke(context);

                            if (context.Response.StatusCode != (int)HttpStatusCode.NoContent)
                            {
                                if (context.Response.StatusCode.ToString().Substring(0, 1) == ((int)HttpStatusCode.OK).ToString().Substring(0, 1))
                                {
                                    var body = await FormatResponse(context.Response);
                                    await HandleSuccessRequestAsync(context, body, context.Response.StatusCode);

                                }
                                else
                                {
                                    var body = await FormatResponse(context.Response);
                                    await HandleNotSuccessRequestAsync(context, body, context.Response.StatusCode);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            await HandleExceptionAsync(context, ex);
                        }
                        finally
                        {
                            responseBody.Seek(0, SeekOrigin.Begin);
                            await responseBody.CopyToAsync(originalBodyStream);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Task for handling request if got an exception
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            ApiError apiError;
            ApiResponse apiResponse;
            List<string> apiMessage = new List<string>();
            int code = 0;
            string responseMessage = string.Empty;

            if (exception is ApiException)
            {
                var ex = exception as ApiException;
                apiError = new ApiError(ex.Message) {
                    ValidationErrors = ex.Errors,
                    ReferenceErrorCode = ex.ReferenceErrorCode,
                    ReferenceDocumentLink = ex.ReferenceDocumentLink
                };
                code = ex.StatusCode;
                context.Response.StatusCode = code;

            }
            else if (exception is UnauthorizedAccessException)
            {
                responseMessage = _stringLocalizer[ApiResponseMessage.Unauthorized];
                apiError = new ApiError(responseMessage);
                code = (int)HttpStatusCode.Unauthorized;
                context.Response.StatusCode = code;
            }
            else
            {
#if !DEBUG
                var msg = "An unhandled error occurred.";
                string stack = null;
#else
                var msg = exception.GetBaseException().Message;
                string stack = exception.StackTrace;
#endif

                apiError = new ApiError(msg) {
                    Details = stack
                };
                code = (int)HttpStatusCode.InternalServerError;
                context.Response.StatusCode = code;
            }

            context.Response.ContentType = "application/json";
            responseMessage = _stringLocalizer[ApiResponseMessage.Failure];
            apiMessage.Add(responseMessage);
            apiResponse = new ApiResponse(code, apiMessage, null, apiError);

            var json = JsonConvert.SerializeObject(apiResponse);

            return context.Response.WriteAsync(json);
        }

        /// <summary>
        /// Task for handling request if failure
        /// </summary>
        /// <param name="context"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        private Task HandleNotSuccessRequestAsync(HttpContext context, object body, int code)
        {
            context.Response.ContentType = "application/json";

            ApiError apiError = null;
            ApiResponse apiResponse = null;
            List<string> apiMessage = new List<string>();
            string bodyText = string.Empty;
            string responseMessage = string.Empty;

            if (!body.ToString().IsValidJson())
                bodyText = JsonConvert.SerializeObject(body);
            else
                bodyText = body.ToString();


            if (code == (int)HttpStatusCode.NotFound)
            {
                responseMessage = _stringLocalizer[ApiResponseMessage.NotFound];
                apiError = new ApiError(responseMessage);
            }
            else if (code == (int)HttpStatusCode.Unauthorized || code == (int)HttpStatusCode.Forbidden)
            {
                responseMessage = _stringLocalizer[ApiResponseMessage.Unauthorized];
                apiMessage.Add(responseMessage);
                apiError = new ApiError(_stringLocalizer[ApiResponseMessage.ContactSupport]);
            }
            else if (code == (int)HttpStatusCode.BadRequest)
            {
                Dictionary<string, List<string>> bodyContent = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(bodyText);
                ModelStateDictionary modelState = new ModelStateDictionary();
                foreach (var item in bodyContent)
                {
                    modelState.AddModelError(item.Key, string.Join(", ", item.Value.ToArray()));
                }

                responseMessage = _stringLocalizer[ApiResponseMessage.ValidationError];
                apiMessage.Add(responseMessage);
                apiError = new ApiError(modelState);
            }
            else
            {
                responseMessage = _stringLocalizer[ApiResponseMessage.ContactSupport];
                apiError = new ApiError(responseMessage);
            }

            responseMessage = _stringLocalizer[ApiResponseMessage.Failure];
            apiMessage.Add(responseMessage);
            apiResponse = new ApiResponse(code, apiMessage, null, apiError);
            context.Response.StatusCode = code;

            var json = JsonConvert.SerializeObject(apiResponse);
            return context.Response.WriteAsync(json);
        }

        /// <summary>
        /// Task for handling request if success
        /// </summary>
        /// <param name="context"></param>
        /// <param name="body"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        private Task HandleSuccessRequestAsync(HttpContext context, object body, int code)
        {
            context.Response.ContentType = "application/json";
            ApiResponse apiResponse = null;
            List<string> apiMessage = new List<string>();
            string jsonString = string.Empty;
            string bodyText = string.Empty;
            string responseMessage = string.Empty;


            if (!body.ToString().IsValidJson())
                bodyText = JsonConvert.SerializeObject(body);
            else
                bodyText = body.ToString();

            dynamic bodyContent = JsonConvert.DeserializeObject<dynamic>(bodyText);
            Type type;

            type = bodyContent?.GetType();

            if (type.Equals(typeof(Newtonsoft.Json.Linq.JObject)))
            {
                apiResponse = JsonConvert.DeserializeObject<ApiResponse>(bodyText);

                if (apiResponse.Result != null)
                    jsonString = JsonConvert.SerializeObject(apiResponse);
                else
                {
                    responseMessage = _stringLocalizer[ApiResponseMessage.Success];
                    apiMessage.Add(responseMessage);
                    apiResponse = new ApiResponse(code, apiMessage, bodyContent, null);
                    jsonString = JsonConvert.SerializeObject(apiResponse);
                }
            }
            else
            {
                responseMessage = _stringLocalizer[ApiResponseMessage.Success];
                apiMessage.Add(responseMessage);
                apiResponse = new ApiResponse(code, apiMessage, bodyContent, null);
                jsonString = JsonConvert.SerializeObject(apiResponse);
            }

            return context.Response.WriteAsync(jsonString);
        }

        /// <summary>
        /// Format http response body to plain text
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private async Task<string> FormatResponse(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            var plainBodyText = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);

            return plainBodyText;
        }

        /// <summary>
        /// Determine an url endpoint is swagger or not
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private bool IsSwagger(HttpContext context)
        {
            return context.Request.Path.StartsWithSegments("/swagger");
        }
    }
}
