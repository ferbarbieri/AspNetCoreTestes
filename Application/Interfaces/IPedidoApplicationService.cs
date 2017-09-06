using Domain.Models;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IPedidoApplicationService
    {

        Pedido ObterPedido(int id);
        
        void AdicionarPedido(Pedido pedido);

        IList<Pedido> ObterPedidosPorCliente(int IdCliente);
    }
}
