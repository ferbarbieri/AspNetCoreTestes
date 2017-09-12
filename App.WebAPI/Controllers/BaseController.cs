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
        
    }
}
