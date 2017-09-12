using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.WebAPI.Attributes
{
    /// <summary>
    /// Tipo de resposta No Content (204)
    /// </summary>
    public class ResponseNoContentAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public ResponseNoContentAttribute() : base(204)
        {
        }

        /// <summary>
        /// Informa o tipo de retorno
        /// </summary>
        /// <param name="type">tipo do retorno</param>
        public ResponseNoContentAttribute(Type type) : base(type, 204)
        {
        }
    }
}
