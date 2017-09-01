using Domain.Events;
using Domain.Models;
using Domain.RepositoryInterfaces;
using SharedKernel;
using System;
using System.Collections.Generic;

namespace Application
{
    public class PedidoApplicationService : IPedidoApplicationService
    {
        private IPedidoRepository _repo { get; }
        public PedidoApplicationService(IPedidoRepository repo)
        {
            _repo = repo;
        }
        
        public Pedido ObterPedido(int id)
        {
            return _repo.GetById(id);
        }

        public void AdicionarPedido(Pedido pedido)
        {
            _repo.Insert(pedido);

            var PedidoEvent = new PedidoCriadoEvent(pedido);
            DomainEvents.Raise(PedidoEvent);
        }

        public IList<Pedido> ObterPedidosPorCliente(int IdCliente)
        {
            return _repo.ObterPedidosPorCliente(IdCliente);
        }
    }
}
