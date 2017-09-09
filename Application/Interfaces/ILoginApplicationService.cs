using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ILoginApplicationService
    {
        Task<Usuario> Login(string usuario, string senha);
    }
}
