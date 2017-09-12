using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.WebAPI.Attributes
{
    /// <summary>
    /// Tipo de resposta BadRequest (201)
    /// </summary>
    public class ResponseBadRequestAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public ResponseBadRequestAttribute() : base(400)
        {
        }

        /// <summary>
        /// Informa o tipo de retorno
        /// </summary>
        /// <param name="type"></param>
        public ResponseBadRequestAttribute(Type type) : base(type, 400)
        {
        }
    }
}
