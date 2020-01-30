using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace BookStore.Application.Middleware
{
    public class JsonAcceptContentType : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await next(context);

            if ((context.Request.ContentType != "application/json"))
            {
                throw new Exception("Only Content-Type Json its Accept in this Application");
            }

            await next(context);
        }


    }
}