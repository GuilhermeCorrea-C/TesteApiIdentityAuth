using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TesteAPIBearer.Models
{
    public class AlunoModel
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        [StringLength(60)]
        public string Nome {get; set; }

        [Required]
        [StringLength(70)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public int Idade {get; set; }
    }
}