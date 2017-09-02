using Domain.Events;
using Domain.Models;
using Domain.RepositoryInterfaces;
using Domain.SharedKernel.Exceptions;
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
            return ObterCliente(id);
        }

        public void Adicionar(string nome)
        {
            var cliente = new Cliente(nome);
            _repo.Insert(cliente);

            var userEvent = new ClienteCriadoEvent(cliente);
           
            DomainEvents.Raise(userEvent);
        }
        
        public PaginatedResults<Cliente> ListarTodos(int paginaAtual, int totalPorPagina)
        {
            return _repo.GetAll(new PaginationInput(paginaAtual, totalPorPagina));
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
            _repo.Delete(ObterCliente(id));
        }

        public void Atualizar(int id, string novoNome)
        {
            var cliente = ObterCliente(id);
            cliente.UpdateInfo(novoNome);
            _repo.Update(cliente);
        }

        private Cliente ObterCliente(int id)
        {
            var cliente = _repo.GetById(id);
            if (cliente == null)
                throw new NotFoundException("Cliente não encontrado", id);

            return cliente;
        }
    }
}
