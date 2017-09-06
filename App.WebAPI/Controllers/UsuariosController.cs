using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application;
using Domain.SharedKernel.Queries;
using Domain.Models;
using Application.Interfaces;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Net;
using Application.Input;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.WebAPI.Controllers
{
    /// <summary>
    /// Controller para operações de usuarios
    /// </summary>
    [Authorize(Policy = "Administradores")]
    [Route("api/[controller]")]
    public class UsuariosController : Controller
    {
        private IUsuarioApplicationService _appService { get; }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="appService">Serviço de aplicação (injetado)</param>
        public UsuariosController(IUsuarioApplicationService appService)
        {
            _appService = appService;
        }

        /// <summary>
        /// Obtém uma lista de usuarios utilizando paginação
        /// </summary>
        /// <param name="pagina">Página atual</param>
        /// <param name="porPagina">Quantidade de itens por página</param>
        /// <returns><see cref="IList{Usuario}"/></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IList<Usuario>), 200)]
        public IActionResult Get(int pagina, int porPagina)
        {
            return Ok(_appService.ListarTodos(pagina, porPagina));
        }

        /// <summary>
        /// Obtém um usuario informando o ID
        /// </summary>
        /// <param name="id">ID do usuario</param>
        /// <returns><see cref="Usuario"/></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Usuario), 200)]
        [ProducesResponseType(404)]
        public IActionResult Get(int id)
        {
            return Ok(_appService.Obter(id));
        }

        /// <summary>
        /// Insere um novo usuario
        /// </summary>
        /// <param name="usuario"><see cref="UsuarioInput"/></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Usuario), 200)]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody] UsuarioInput usuario)
        {
            _appService.Adicionar(usuario);
            return Ok();
        }

        /// <summary>
        /// Altera informações de um usuario
        /// </summary>
        /// <param name="id">Identificação do usuario</param>
        /// <param name="usuario"><see cref="UsuarioInput"/></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Put(int id, [FromBody]UsuarioInput usuario)
        {
            _appService.Atualizar(id, usuario);
            return Ok();
        }

        /// <summary>
        /// Exclui um Usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult Delete(int id)
        {
            _appService.Excluir(id);
            return Ok();
        }
    }
}
