using Domain.Models;
using System.Collections.Generic;

namespace Domain.RepositoryInterfaces
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        IList<Pedido> ObterPedidosPorCliente(int idCliente);
    }
}
