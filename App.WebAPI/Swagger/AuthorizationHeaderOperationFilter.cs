using Microsoft.AspNetCore.Mvc.Authorization;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.WebAPI.Swagger
{
    /// <summary>
    /// Filtro para que o swagger possa utilizar o campo de autenticação
    /// </summary>
    public class AuthorizationHeaderOperationFilter : IOperationFilter
    {
        /// <summary>
        /// Faz a inclusão do campo Autentication quando for uma pagina que precisa de autorização
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="context"></param>
        public void Apply(Operation operation, OperationFilterContext context)
        {
            var filterPipeline = context.ApiDescription.ActionDescriptor.FilterDescriptors;
            var isAuthorized = filterPipeline.Select(filterInfo => filterInfo.Filter).Any(filter => filter is AuthorizeFilter);
            var allowAnonymous = filterPipeline.Select(filterInfo => filterInfo.Filter).Any(filter => filter is IAllowAnonymousFilter);

            if (isAuthorized && !allowAnonymous)
            {
                if (operation.Parameters == null)
                    operation.Parameters = new List<IParameter>();

                operation.Parameters.Add(new NonBodyParameter
                {
                    Name = "Authorization",
                    In = "header",
                    Description = "Utilizar: bearer {token}",
                    Required = true,
                    Type = "string"
                });
            }
        }
    }
}
