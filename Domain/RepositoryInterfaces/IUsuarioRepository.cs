using Domain.Models;

namespace Domain.RepositoryInterfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario GetByEmail(string email);
    }
}
