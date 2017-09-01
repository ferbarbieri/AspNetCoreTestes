using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Application;
using Domain.Models;

namespace AspNetCoreTestes.Controllers
{
    public class HomeController : Controller
    {
        private IUsuarioApplicationService _userService;
        private IPedidoApplicationService _pedidoService;


        public HomeController(IUsuarioApplicationService userService, IPedidoApplicationService pedidoService)
        {
            _userService = userService;
            _pedidoService = pedidoService;
        }

        public IActionResult Index()
        {
            Logger.Log("Iniciou");

            var user = _userService.ObterUsuario(1);

            var userAdd = new Usuario ("Fernando");

            _userService.AdicionarUsuario(userAdd);

            return View();
        }

        public IActionResult About()
        {
            Logger.Log("About");

            ViewData["Message"] = "Your application description page.";

            // Inserir um Pedido
            /*
            var pedido = new Pedido(
                itens : new List<Produto>
                {
                    new Produto{ Id=1, Nome="Bicicleta", Preco = 1000 },
                    new Produto{ Id=2, Nome="Monociclo", Preco = 100 }
                },
                cliente : new Cliente
                {
                    Name = "Fernand Barbieri"
                }
            };

            _pedidoService.AdicionarPedido(pedido);
            */
            return View();
        }

        public IActionResult Contact()
        {
            Logger.Trace("Contact");
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            Logger.Fatal("Errão");
            return View();
        }
    }
}
