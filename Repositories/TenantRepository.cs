using Domain.Models;
using Domain.RepositoryInterfaces;
using Infra.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories
{
    public class TenantRepository : Repository<Tenant, TenantManagementContext>, ITenantRepository
    {
        public TenantRepository(TenantManagementContext context) : base(context)
        {
        }

        public Task<Tenant> ObterPeloDominio(string dominio)
        {
            return DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Dominio == dominio);
        }
    }
}
