using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace App.WebAPI.Controllers
{
    /// <summary>
    /// Classe base para todos os outros controllers
    /// </summary>
    public abstract class BaseController : Controller
    {
        /// <summary>
        /// Retorna 204 No Content
        /// </summary>
        /// <returns></returns>
        protected IActionResult Deleted()
        {
            return NoContent();
        }

        /// <summary>
        /// Retorna 201 No Created
        /// </summary>
        /// <returns></returns>
        protected IActionResult Created<T>(string rota, int id, T objeto) where T : class
        {
            return CreatedAtRoute(rota, new { id = id }, objeto);
        }
    }
}
