using Domain.Models;
using Domain.RepositoryInterfaces;
using System;

namespace Application
{
    public interface IUsuarioApplicationService
    {

        Usuario ObterUsuario(int id);
        
        void AdicionarUsuario(Usuario user);
        
    }
}
