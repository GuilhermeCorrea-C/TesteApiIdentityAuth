using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteAPIBearer.Models;

namespace TesteAPIBearer.Services
{
    public interface IAlunoService
    {
        Task<IEnumerable<AlunoModel>> GetAlunos();
        Task<AlunoModel> GetAlunoById(int id); 
        Task<AlunoModel> CreateAluno (AlunoModel aluno);
        Task<AlunoModel> UpdateAluno (AlunoModel aluno,int id);
        Task<bool> DeleteAluno(int id);
    }
}