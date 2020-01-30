using BookStore.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace BookStore.Application.Middleware
{
    public class GlobalExceptionHandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }   
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            
            context.Response.StatusCode = context.Response.StatusCode < 400 ? 
                (int) HttpStatusCode.InternalServerError : context.Response.StatusCode;

            return context.Response.WriteAsync(JsonConvert.SerializeObject(
                new ResponseEntity { Status = context.Response.StatusCode,
                    Message = String.Format("An error occurred whilst processing your request ( {0} )", exception.Message),
                    Detailed = exception
                }));
        }
    }
}