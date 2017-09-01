using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application;
using Domain.SharedKernel.Queries;
using Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private IClienteApplicationService _appService { get; }

        public ClienteController(IClienteApplicationService appService)
        {
            _appService = appService;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get(int pagina, int porPagina)
        {
            return Ok(_appService.ListarTodos(pagina, porPagina));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_appService.Obter(id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]string nome)
        {
            _appService.Adicionar(nome);
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string novoNome)
        {
            _appService.Atualizar(id, novoNome);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _appService.Excluir(id);
            return Ok();
        }
    }
}
