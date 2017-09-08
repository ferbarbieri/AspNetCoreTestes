using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface ILoginApplicationService
    {
        Usuario Login(string usuario, string senha);
    }
}
