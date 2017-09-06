using AspNetCoreTestes.UserServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace AspNetCoreTestes.Middleware
{
    public sealed class RequestMiddleware
    {
        private readonly IUserService userService;

        public RequestMiddleware(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task Invoke(HttpContext context, Func<Task> next)
        {
            //Logger.Log("Middleware: Antes de invocar");
            await next();
            // Do something after
            //Logger.Log("Middleware: Após invocar");
        }
    }
}
