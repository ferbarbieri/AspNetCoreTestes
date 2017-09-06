using Domain.Models;
using Domain.RepositoryInterfaces;
using Infra.Repositories.Contexts;

namespace Repositories
{
    public class ClienteRepository : Repository<Cliente, LojaContext>, IClienteRepository
    {
        public ClienteRepository(LojaContext context) : base(context)
        {
        }
    }
}
