using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteAPIBearer.ViewModels
{
    public class UserTokenViewModel
    {
        public string Token { get; set; }   
        public DateTime Expiration { get; set; }
    }
}