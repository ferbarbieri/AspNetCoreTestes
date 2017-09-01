using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreTestes.UserServices
{
    public class UserService : IUserService
    {
        public Usuario GetCurrentUser()
        {
            return new Usuario("Fernando");
        }
    }
}
