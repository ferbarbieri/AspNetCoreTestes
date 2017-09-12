using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.WebAPI.Attributes
{
    /// <summary>
    /// Tipo de resposta OK
    /// </summary>
    public class ResponseOKAttribute : ProducesResponseTypeAttribute
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public ResponseOKAttribute() : base(200)
        {
        }

        /// <summary>
        /// Informa o tipo de retorno
        /// </summary>
        /// <param name="type">tipo do retorno</param>
        public ResponseOKAttribute(Type type) : base(type, 200)
        {
        }
    }
}
