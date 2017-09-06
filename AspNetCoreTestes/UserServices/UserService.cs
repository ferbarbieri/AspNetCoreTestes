using Domain.Models;

namespace AspNetCoreTestes.UserServices
{
    public class UserService : IUserService
    {
        public Usuario GetCurrentUser()
        {
            return new Usuario("Fernando", "fernando@viceri", "123456789");
        }
    }
}
