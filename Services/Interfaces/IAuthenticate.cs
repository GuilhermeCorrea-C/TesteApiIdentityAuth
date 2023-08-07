using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteAPIBearer.Services.Interfaces
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate(string email, string senha);
        Task<bool> RegisterUser(string email, string senha);
        Task Logout();
    }
}