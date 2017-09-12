using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.WebAPI.Attributes
{
    /// <summary>
    /// Tipo de resposta Not Found (404)
    /// </summary>
    public class ResponseNotFoundAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public ResponseNotFoundAttribute() : base(404)
        {
        }

        /// <summary>
        /// Informa o tipo de retorno
        /// </summary>
        /// <param name="type">tipo do retorno</param>
        public ResponseNotFoundAttribute(Type type) : base(type, 404)
        {
        }
    }
}
