using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.WebAPI.Middleware
{
    /// <summary>
    /// Middleware para todas as requisições da api
    /// </summary>
    public sealed class ApiRequestMiddleware
    {
        /// <summary>
        /// Default do middleware
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context, Func<Task> next)
        {
            //Logger.Log("Middleware: Antes de invocar");
            await next();
            // Do something after
            //Logger.Log("Middleware: Após invocar");
        }
    }
}
