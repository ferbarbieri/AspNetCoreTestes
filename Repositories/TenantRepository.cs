using Domain.Models;
using Domain.RepositoryInterfaces;
using Infra.Repositories.Contexts;
using System.Linq;

namespace Repositories
{
    public class TenantRepository : Repository<Tenant, TenantManagementContext>, ITenantRepository
    {
        public TenantRepository(TenantManagementContext context) : base(context)
        {
        }

        public Tenant ObterPeloDominio(string dominio)
        {
            return DbSet.FirstOrDefault(c => c.Dominio == dominio);
        }
    }
}
