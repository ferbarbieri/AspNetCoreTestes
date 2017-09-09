using Application.Input;
using Application.Interfaces;
using Domain.Events;
using Domain.Models;
using Domain.RepositoryInterfaces;
using Domain.SharedKernel.Exceptions;
using Domain.SharedKernel.Queries;
using SharedKernel;
using System.Threading.Tasks;

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

        public Task<Cliente> Obter(int id)
        {
            return ObterCliente(id);
        }

        public Task<PaginatedResults<Cliente>> ListarTodos(int paginaAtual, int totalPorPagina)
        {
            return _repo.GetAll(new PaginationInput(paginaAtual, totalPorPagina));
        }

        public Task<PaginatedResults<Cliente>> FiltrarPorNome(string nome, int paginaAtual, int totalPorPagina)
        {
            return _repo.GetAllBy(
                c => c.Nome.StartsWith(nome),
                new PaginationInput(paginaAtual, totalPorPagina)
                );
        }

        #endregion

        #region Commands

        public async Task Adicionar(ClienteInput cliente)
        {
            var c = new Cliente(cliente.Nome);
            await _repo.Insert(c);

            var userEvent = new ClienteCriadoEvent(c);
           
            DomainEvents.Raise(userEvent);
        }
        

        public async Task Excluir(int id)
        {
            await _repo.Delete(await ObterCliente(id));
        }

        public async Task Atualizar(int id, ClienteInput cliente)
        {
            var c = await ObterCliente(id);
            c.UpdateInfo(cliente.Nome);
            await _repo.Update(c);
        }

        #endregion

        private Task<Cliente> ObterCliente(int id)
        {
            var cliente = _repo.GetById(id);
            if (cliente == null)
                throw new NotFoundException("Cliente não encontrado", id);

            return cliente;
        }
    }
}
