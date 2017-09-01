using Domain.Events;
using Domain.Models;
using Domain.RepositoryInterfaces;
using Domain.SharedKernel.Queries;
using SharedKernel;
using System;
using System.Collections.Generic;

namespace Application
{
    public class ClienteApplicationService : IClienteApplicationService
    {
        private IClienteRepository _repo { get; }
        public ClienteApplicationService(IClienteRepository repo)
        {
            _repo = repo;
        }
        
        public Cliente Obter(int id)
        {
            return _repo.GetById(id);
        }

        public void Adicionar(Cliente cliente)
        {
            _repo.Insert(cliente);

            var userEvent = new ClienteCriadoEvent(cliente);

            // Registro dinamico de evento:
            DomainEvents.Register<ClienteCriadoEvent>((args) =>
            {
                Logger.Log($"Cliente foi crado: {args.Cliente.Nome}, Gerar registro e enviar email de confirmação.");
            });

            DomainEvents.Raise(userEvent);
        }
        
        public PaginatedResults<Cliente> ListarTodos(int paginaAtual, int itensPorPagina)
        {
            return _repo.GetAll(new PaginationInput(paginaAtual, itensPorPagina));
        }

        public PaginatedResults<Cliente> FiltrarPorNome(string nome, int paginaAtual, int itensPorPagina)
        {
            return _repo.GetAllBy(
                c => c.Nome.StartsWith(nome), 
                new PaginationInput(paginaAtual, itensPorPagina)
                );
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        
    }
}
