using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteAPIBearer.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email é obrigatório!")]
        [EmailAddress(ErrorMessage= "Formato de email inválido.")]
        public string Email { get; set; }  

        [Required(ErrorMessage = "A senha é obrigatória!")]
        [StringLength(20, MinimumLength = 10)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}