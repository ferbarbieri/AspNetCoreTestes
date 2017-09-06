using Domain.Models;
using Domain.RepositoryInterfaces;
using Infra.Repositories.Contexts;
using System.Linq;

namespace Repositories
{
    public class UsuarioRepository : Repository<Usuario, AdminContext>, IUsuarioRepository
    {
        public UsuarioRepository(AdminContext context) : base(context)
        {
        }

        public Usuario GetByEmail(string email)
        {
            return DbSet.FirstOrDefault(u => u.Email == email);
        }
    }
}
