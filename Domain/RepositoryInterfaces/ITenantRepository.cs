using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterfaces
{
    public interface ITenantRepository : IRepository<Tenant>
    {
        Task<Tenant> ObterPeloDominio(string dominio);
    }
}
