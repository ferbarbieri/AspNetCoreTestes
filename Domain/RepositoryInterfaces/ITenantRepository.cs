using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.RepositoryInterfaces
{
    public interface ITenantRepository : IRepository<Tenant>
    {
        Tenant ObterPeloDominio(string dominio);
    }
}
