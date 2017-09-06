using Domain.SharedKernel.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace App.WebAPI.Middleware
{
    /// <summary>
    /// Middleware pare gerenciar erros
    /// </summary>
    public class ErrorHandlerMiddleware
    {
        
        /// <summary>
        /// Padrão de middleware
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context, Func<Task> next)
        {
            try
            {
                await next();
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode code;
            
            switch (exception)
            {
                case NotFoundException nfEx:
                    code = HttpStatusCode.NotFound;
                    break;
                case FieldsValidationException fvEx:
                case UserLoginFailedException ulfEx:
                    code = HttpStatusCode.BadRequest;
                    break;
                default:
                    code = HttpStatusCode.InternalServerError; // 500 se for qualquer outro erro
                    break;
            }
        
            var result = JsonConvert.SerializeObject(new { Erro = exception.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
