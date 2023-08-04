using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteAPIBearer.Context;
using TesteAPIBearer.Models;

namespace TesteAPIBearer.Services
{
    public class AlunoService : IAlunoService
    {

        private readonly AppDbContext _appDbContext;

        public AlunoService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<IEnumerable<AlunoModel>> GetAlunos()
        {
            try{
                return await _appDbContext.Alunos.ToListAsync();
            }
            catch{
                throw;
            }
        }

        public async Task<AlunoModel> GetAlunoById(int id)
        {
            var alunoDB = await _appDbContext.Alunos.SingleOrDefaultAsync(a => a.Id == id);  
            if (alunoDB == null){
                throw new Exception("Aluno não encontrado");
            }
            else{
                return alunoDB;
            }
        }

        public async Task<AlunoModel> CreateAluno(AlunoModel aluno)
        {
            await _appDbContext.Alunos.AddAsync(aluno);
            await _appDbContext.SaveChangesAsync();

            return aluno;

        }
        public async Task<bool> DeleteAluno(int id)
        {
            var alunoDb = await GetAlunoById(id);   
            if(alunoDb == null){
                throw new Exception("Aluno não encontrado");
                return false;
            }else{
                _appDbContext.Alunos.Remove(alunoDb);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<AlunoModel> UpdateAluno(AlunoModel aluno, int id)
        {
            var alunoDb = await GetAlunoById(id);
            if(alunoDb == null){
                throw new Exception("Aluno não encontrado");
            }else{
                alunoDb.Id = aluno.Id;
                alunoDb.Nome = aluno.Nome;
                alunoDb.Email = aluno.Email;
                alunoDb.Idade = aluno.Idade;

                _appDbContext.Alunos.Update(alunoDb);
                await _appDbContext.SaveChangesAsync();

                return alunoDb;
            }
        }
    }
}