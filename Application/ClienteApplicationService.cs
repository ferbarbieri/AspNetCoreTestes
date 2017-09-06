using Application.Input;
using Application.Interfaces;
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

        #region Queries

        public Cliente Obter(int id)
        {
            return ObterCliente(id);
        }

        public PaginatedResults<Cliente> ListarTodos(int paginaAtual, int totalPorPagina)
        {
            return _repo.GetAll(new PaginationInput(paginaAtual, totalPorPagina));
        }

        public PaginatedResults<Cliente> FiltrarPorNome(string nome, int paginaAtual, int totalPorPagina)
        {
            return _repo.GetAllBy(
                c => c.Nome.StartsWith(nome),
                new PaginationInput(paginaAtual, totalPorPagina)
                );
        }

        #endregion

        #region Commands

        public void Adicionar(ClienteInput cliente)
        {
            var c = new Cliente(cliente.Nome);
            _repo.Insert(c);

            var userEvent = new ClienteCriadoEvent(c);
           
            DomainEvents.Raise(userEvent);
        }
        

        public void Excluir(int id)
        {
            _repo.Delete(ObterCliente(id));
        }

        public void Atualizar(int id, ClienteInput cliente)
        {
            var c = ObterCliente(id);
            c.UpdateInfo(cliente.Nome);
            _repo.Update(c);
        }

        #endregion

        private Cliente ObterCliente(int id)
        {
            var cliente = _repo.GetById(id);
            if (cliente == null)
                throw new NotFoundException("Cliente não encontrado", id);

            return cliente;
        }
    }
}
