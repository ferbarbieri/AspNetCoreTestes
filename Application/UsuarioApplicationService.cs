using Domain.Events;
using Domain.Models;
using Domain.RepositoryInterfaces;
using SharedKernel;
using System;

namespace Application
{
    public class UsuarioApplicationService : IUsuarioApplicationService
    {
        private IUsuarioRepository _repo { get; }
        public UsuarioApplicationService(IUsuarioRepository repo)
        {
            _repo = repo;
        }
        
        public Usuario ObterUsuario(int id)
        {
            return _repo.GetById(id);
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            _repo.Insert(usuario);

            var userEvent = new UsuarioCriadoEvent(usuario);

            // Registro dinamico de evento:
            DomainEvents.Register<UsuarioCriadoEvent>((args) =>
            {
                Logger.Log("aohouuu:" + args.Usuario.Nome);
            });

            DomainEvents.Raise(userEvent);
        }
    }
}
