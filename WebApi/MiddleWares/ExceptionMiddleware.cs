using Core.Exceptions;
using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebApi.MiddleWares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            if (exception is ConcurrencyException concurrencyException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                await context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = concurrencyException.Message
                }.ToString());
            }

            if (exception is EntityNotFoundException entityNotFoundException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                await context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = (int) HttpStatusCode.BadRequest,
                    Message = entityNotFoundException.Message
                }.ToString());
            }
        }
    }
}
