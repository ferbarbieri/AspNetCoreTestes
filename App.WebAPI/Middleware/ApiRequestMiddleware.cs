using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.WebAPI.Middleware
{
    public sealed class ApiRequestMiddleware
    {
        public async Task Invoke(HttpContext context, Func<Task> next)
        {
            //Logger.Log("Middleware: Antes de invocar");
            await next();
            // Do something after
            //Logger.Log("Middleware: Após invocar");
        }
    }
}
