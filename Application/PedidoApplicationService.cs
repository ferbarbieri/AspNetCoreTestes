using Application.Interfaces;
using Domain.Events;
using Domain.Models;
using Domain.RepositoryInterfaces;
using SharedKernel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application
{
    public class PedidoApplicationService : IPedidoApplicationService
    {
        private IPedidoRepository _repo { get; }
        public PedidoApplicationService(IPedidoRepository repo)
        {
            _repo = repo;
        }

        #region Queries

        public async Task<Pedido> ObterPedido(int id)
        {
            return await _repo.GetById(id);
        }

        public async Task<IList<Pedido>> ObterPedidosPorCliente(int IdCliente)
        {
            return await _repo.ObterPedidosPorCliente(IdCliente);
        }

        #endregion

        #region Commands

        public async Task AdicionarPedido(Pedido pedido)
        {
            await _repo.Insert(pedido);

            var PedidoEvent = new PedidoCriadoEvent(pedido);
            DomainEvents.Raise(PedidoEvent);
        }

        #endregion

    }
}
