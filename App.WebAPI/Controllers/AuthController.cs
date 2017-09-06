using App.WebAPI.ViewModels;
using Application.Interfaces;
using Domain.SharedKernel.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace App.WebAPI.Controllers
{

    /// <summary>
    /// Controller de Autenticação
    /// </summary>
    [Authorize]
    [Produces("application/json")]
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        private IUsuarioApplicationService _userService;
        private IConfigurationRoot _config;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="userService">Serviço de Usuario</param>
        /// <param name="config">Configurações (settings.json)</param>
        public AuthController(IUsuarioApplicationService userService, IConfigurationRoot config)
        {
            _userService = userService;
            _config = config;

        }
        /// <summary>
        /// Gera um token JWT que deverá ser utilizado para todas as operações subsequentes.
        /// Deve enviar no HEADER das solicitações um header Authorization com o valor "bearer {token}"
        /// </summary>
        /// <param name="login"><see cref="LoginViewModel"/></param>
        /// <returns>JWT Bearer Token</returns>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Login([FromBody] LoginViewModel login)
        {
            if (login == null)
                return BadRequest("Credenciais não informadas");

            var user = _userService.Login(login.Email, login.Senha);

            if(user != null)
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.GivenName, user.Nome),
                    new Claim("Profile", user.Perfil.ToString()),
                };
                // Adicionar roles

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                  _config["Tokens:Issuer"],
                  claims,
                  expires: DateTime.Now.AddMinutes(30),
                  signingCredentials: creds);

                // Tudo certo. devolve o token
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }

            throw new UserLoginFailedException();
        }
    }
}