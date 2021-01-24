using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security.Authentication;
using System.Threading.Tasks;
using TaxService.Exceptions;

namespace TaxService.Middleware
{
    /// <summary>
    /// Global error/exception handler middleware.
    /// </summary>
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate request;
        
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            this.request = next;
        }

        public Task Invoke(HttpContext context)
        {
            return this.InvokeAsync(context);
        }

        /// <summary>
        /// Invoked the current request and handles its exceptions.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await this.request(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        /// <summary>
        /// Returns error response with apprporiate Http codd and error message.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = (int)GetErrorCode(exception);
            context.Response.ContentType = "application/json";
            var result = JsonConvert.SerializeObject(new { Error = exception.Message });
            return context.Response.WriteAsync(result);
        }

        /// <summary>
        /// Returns Http status based on the exception that occured.
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        private HttpStatusCode GetErrorCode(Exception ex)
        {
            if (ex is ValidationException)
            {
                return HttpStatusCode.BadRequest;
            }
            else if (ex is FormatException)
            {
                return HttpStatusCode.BadRequest;
            }
            else if (ex is AuthenticationException)
            {
                return HttpStatusCode.Forbidden;
            }
            else if (ex is NotImplementedException)
            {
                return HttpStatusCode.NotImplemented;
            }
            else if (ex is TaxRateNotFoundException || ex is OrderTaxNotFoundException)
            {
                return HttpStatusCode.NotFound;
            }
            else
            {
                return HttpStatusCode.InternalServerError;
            }
        }
    }
}