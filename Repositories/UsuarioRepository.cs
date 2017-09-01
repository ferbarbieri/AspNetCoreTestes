using Domain.Models;
using Domain.RepositoryInterfaces;
using Infra.Repositories.Contexts;
using System;

namespace Repositories
{
    public class UsuarioRepository : Repository<Usuario, AdminContext>, IUsuarioRepository
    {
        public UsuarioRepository(AdminContext context) : base(context)
        {
        }
    }
}
