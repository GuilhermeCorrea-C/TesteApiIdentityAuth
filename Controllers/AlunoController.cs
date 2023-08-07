using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TesteAPIBearer.Models;
using TesteAPIBearer.Services;

namespace TesteAPIBearer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _alunoService;

        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet]
        public async Task<IEnumerable<AlunoModel>> GetAlunos()
        {
            return await _alunoService.GetAlunos();    
        }

        [HttpGet("{id}")]
        public async Task<AlunoModel> ObterAlunoByID(int id)
        {
            return await _alunoService.GetAlunoById(id);
        }

        [HttpPost]
        public async Task<AlunoModel> CriarAluno([FromBody]AlunoModel aluno)
        {
            return await _alunoService.CreateAluno(aluno);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteAluno(int id )
        {
            return await _alunoService.DeleteAluno(id);
        }

        [HttpPut("{id}")]
        public async Task<AlunoModel> AtualizarAluno([FromBody]AlunoModel aluno, int id)
        {
            return await _alunoService.UpdateAluno(aluno, id);
        }
    }
}