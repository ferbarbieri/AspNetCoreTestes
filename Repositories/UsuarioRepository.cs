using Domain.Models;
using Domain.RepositoryInterfaces;
using Infra.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories
{
    public class UsuarioRepository : Repository<Usuario, AdminContext>, IUsuarioRepository
    {
        public UsuarioRepository(AdminContext context) : base(context)
        {
        }

        public Task<Usuario> GetByEmail(string email)
        {
            return DbSet.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
