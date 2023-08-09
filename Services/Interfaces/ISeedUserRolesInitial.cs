using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteAPIBearer.Services.Interfaces
{
    public interface ISeedUserRolesInitial
    {
        Task SeedRolesAsync();
        Task SeedUsersAsync();
    }
}