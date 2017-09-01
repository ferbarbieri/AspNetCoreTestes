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
        public PaginatedResults<Cliente> Get(int pagina, int porPagina)
        {
            return _appService.ListarTodos(pagina, porPagina);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
