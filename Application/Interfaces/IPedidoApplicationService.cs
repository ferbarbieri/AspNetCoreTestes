using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPedidoApplicationService
    {

        Task<Pedido> ObterPedido(int id);
        
        Task AdicionarPedido(Pedido pedido);

        Task<IList<Pedido>> ObterPedidosPorCliente(int IdCliente);
    }
}
