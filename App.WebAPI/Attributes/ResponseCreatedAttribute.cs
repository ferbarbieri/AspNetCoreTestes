using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.WebAPI.Attributes
{
    /// <summary>
    /// Tipo de resposta Created (201)
    /// </summary>
    public class ResponseCreatedAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public ResponseCreatedAttribute() : base(201)
        {
        }

        /// <summary>
        /// Informa o tipo de retorno
        /// </summary>
        /// <param name="type">tipo do retorno</param>
        public ResponseCreatedAttribute(Type type) : base(type, 201)
        {
        }
    }
}
