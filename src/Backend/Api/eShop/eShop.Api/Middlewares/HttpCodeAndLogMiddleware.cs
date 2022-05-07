using eShop.Core.ExceptionHandling;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Api.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class HttpCodeAndLogMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger<HttpCodeAndLogMiddleware> _logger;

        public HttpCodeAndLogMiddleware(RequestDelegate next, ILogger<HttpCodeAndLogMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if(httpContext == null)
            {
                return;
            }

            try
            {
                httpContext.Request.EnableBuffering();
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                var response = httpContext.Response;
                response.ContentType = "application/json";

                switch(exception)
                {
                    case ApiException e:

                        httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        await WriteAndLogResponseAync(exception, httpContext, HttpStatusCode.BadRequest, LogLevel.Error, "BadRequest Exception!" + e.Message);
                        break;

                    //case NotFoundException e:

                    //    httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    //    await WriteAndLogResponseAync(exception, httpContext, HttpStatusCode.NotFound, LogLevel.Error, "Not Found!" + e.Message);
                    //    break;

                    //case ValidationException e:

                    //    httpContext.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                    //    await WriteAndLogResponseAync(exception, httpContext, HttpStatusCode.InternalServerError, LogLevel.Error, "Validation Exception!" + e.Message);
                    //    break;

                    //case AuthenticationException e:

                    //    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    //    await WriteAndLogResponseAync(exception, httpContext, HttpStatusCode.Unauthorized, LogLevel.Error, "AuthenticationException!" + e.Message);
                    //    break;

                    default:
                        //httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        await WriteAndLogResponseAync(exception, httpContext, HttpStatusCode.InternalServerError, LogLevel.Error, "Not Found!" + e.Message);
                        break;
    
                }

                //throw;
            }

            //return await _next(httpContext);
        }

        // WriteAndLogResponseAsync
        private async Task WriteAndLogResponseAync(
            Exception exception,
            HttpContext httpContext,
            HttpStatusCode httpStatusCode,
            LogLevel logLevel,
            string alternateMessage = null)
        {
            string requestBody = string.Empty;
            if (httpContext.Request.Body.CanSeek)
            {
                httpContext.Request.Body.Seek(0, System.IO.SeekOrigin.Begin);
                using (var sr = new System.IO.StreamReader(httpContext.Request.Body))
                {
                    requestBody = JsonConvert.SerializeObject(sr.ReadToEndAsync());
                }
            }


            StringValues authorization;
            httpContext.Request.Headers.TryGetValue("Authorization", out authorization);

            var customDetails = new StringBuilder();
            customDetails
                .AppendFormat("\n  Service URL    :").Append(httpContext.Request.Path.ToString())
                .AppendFormat("\n  Request Method :").Append(httpContext.Request?.Method)
                .AppendFormat("\n  Request Body   :").Append(requestBody)
                .AppendFormat("\n  Authorization  :").Append(authorization)
                .AppendFormat("\n  Content-Type   :").Append(httpContext.Request.Headers["Content-Type"].ToString())
                .AppendFormat("\n  Cookie         :").Append(httpContext.Request.Headers["Cookie"].ToString())
                .AppendFormat("\n  Host           :").Append(httpContext.Request.Headers["Host"].ToString())
                .AppendFormat("\n  Referer        :").Append(httpContext.Request.Headers["Referer"].ToString())
                .AppendFormat("\n  Origin         :").Append(httpContext.Request.Headers["Origin"].ToString())
                .AppendFormat("\n  User-Agent     :").Append(httpContext.Request.Headers["User-Agent"].ToString())
                .AppendFormat("\n  Error Message  :").Append(exception.Message);

            _logger.Log(logLevel, exception, customDetails.ToString());

            if (httpContext.Response.HasStarted)
            {
                _logger.LogError("The response has already started, the http status code middleware will not be executed");
                return;
            }

            string responseMessage = JsonConvert.SerializeObject(
                new
                {
                    Message = string.IsNullOrWhiteSpace(exception.Message) ? alternateMessage : exception.Message,
                }
            );

            httpContext.Response.Clear();
            httpContext.Response.ContentType = System.Net.Mime.MediaTypeNames.Application.Json;
            httpContext.Response.StatusCode = (int)httpStatusCode;
            await httpContext.Response.WriteAsync(responseMessage, Encoding.UTF8);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class HttpCodeAndLogMiddlewareExtensions
    {
        public static IApplicationBuilder UseHttpCodeAndLogMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HttpCodeAndLogMiddleware>();
        }
    }

    
}
