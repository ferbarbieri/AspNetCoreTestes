using Domain.Models;
using Domain.RepositoryInterfaces;
using Infra.Repositories.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class PedidoRepository : Repository<Pedido, LojaContext>, IPedidoRepository
    {
        public PedidoRepository(LojaContext context) : base(context)
        {
        }

        public IList<Pedido> ObterPedidosPorCliente(int idCliente)
        {
            return DbSet.Where(p => p.Cliente.Id == idCliente).ToList();
        }
    }
}
