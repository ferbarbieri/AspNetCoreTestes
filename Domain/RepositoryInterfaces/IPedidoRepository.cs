using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.RepositoryInterfaces
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task<List<Pedido>> ObterPedidosPorCliente(int idCliente);
    }
}
