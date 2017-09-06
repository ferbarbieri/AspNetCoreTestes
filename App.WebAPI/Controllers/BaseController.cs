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
        /// Usuario logado
        /// </summary>
        public UsuarioViewModel Usuario => ObterUsuario();

        private UsuarioViewModel _usuario;

        private UsuarioViewModel ObterUsuario()
        {
            // Se já pegou uma vez, retorna o mesmo.
            if (_usuario != null)
                return _usuario;

            var usuario = new UsuarioViewModel();

            //TODO: Deve ter um jeito melhor de fazer isso:
            var identity = User.Identity as ClaimsIdentity;
            if (identity == null)
                return null;

            var claims = identity.Claims.ToList();
            var id = GetClaimValue(claims, JwtRegisteredClaimNames.Jti);

            usuario.Id = int.Parse(id);
            usuario.Nome = GetClaimValue(claims, ClaimTypes.GivenName);
            usuario.Email = GetClaimValue(claims, ClaimTypes.Email);
            usuario.Perfil = GetClaimValue(claims, "Profile");

            _usuario = usuario;
            return _usuario;
        }

        private string GetClaimValue(IList<Claim> claims, string type)
        {
            return claims.FirstOrDefault(c => c.Type == type)?.Value;
        }
    }
}
