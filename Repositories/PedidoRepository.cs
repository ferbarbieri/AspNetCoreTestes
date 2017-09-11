using Domain.Models;
using Domain.RepositoryInterfaces;
using Infra.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories
{
    public class PedidoRepository : Repository<Pedido, LojaContext>, IPedidoRepository
    {
        public PedidoRepository(LojaContext context) : base(context)
        {
        }

        public Task<List<Pedido>> ObterPedidosPorCliente(int idCliente)
        {
            return DbSet.AsNoTracking().Where(p => p.Cliente.Id == idCliente).ToListAsync();
        }
    }
}
