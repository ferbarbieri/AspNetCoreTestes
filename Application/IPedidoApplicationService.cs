using Domain.Models;
using Domain.RepositoryInterfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Application
{
    public interface IPedidoApplicationService
    {

        Pedido ObterPedido(int id);
        
        void AdicionarPedido(Pedido pedido);

        IList<Pedido> ObterPedidosPorCliente(int IdCliente);
    }
}
