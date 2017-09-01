using Domain.Models;

namespace AspNetCoreTestes.UserServices
{
    public interface IUserService
    {
        Usuario GetCurrentUser();
    }
}