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
        private readonly IUsuarioApplicationService _userService;
        private readonly IPedidoApplicationService _pedidoService;


        public HomeController(IUsuarioApplicationService userService, IPedidoApplicationService pedidoService)
        {
            _userService = userService;
            _pedidoService = pedidoService;
        }

        public IActionResult Index()
        {
            Logger.Log("Iniciou");
            
            var userAdd = new Usuario ("Fernando");

            _userService.AdicionarUsuario(userAdd);

            return View();
        }

        public IActionResult About()
        {
            Logger.Log("About");

            ViewData["Message"] = "Your application description page.";
            
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
