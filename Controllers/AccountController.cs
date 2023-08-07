using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TesteAPIBearer.Services.Interfaces;
using TesteAPIBearer.ViewModels;

namespace TesteAPIBearer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthenticate _authenticate;

        public AccountController(IConfiguration configuration, IAuthenticate authenticate)
        {
            _configuration = configuration;
            _authenticate = authenticate;            
        }
        
        [HttpPost("CreateUser")]
        public async Task<ActionResult<UserTokenViewModel>> CreateUser([FromBody] RegisterViewModel model)
        {
            if(model.Senha != model.ConfirmarSenha)
            {
                ModelState.AddModelError("ConfirmarSenha", "As senhas não conferem!");
                return BadRequest(ModelState);
            }

            var usuario = await _authenticate.RegisterUser(model.Email, model.Senha);
            Console.WriteLine($"{model.Email} {model.Senha}");

            if(usuario)
            {
                return Ok($"Usuário {model.Email} criado com sucesso");
            }
            else
            {
                ModelState.AddModelError("CreateUser", "Registro inválido.");
                 return BadRequest(ModelState);
            }
        }

        [HttpPost("LoginUser")]
        public async Task<ActionResult<UserTokenViewModel>> LoginUser([FromBody] LoginViewModel userInfo)
        {
            var auth = await _authenticate.Authenticate(userInfo.Email, userInfo.Password);

            if(auth)
            {
                return GenerateToken(userInfo);
            }
            else{
                ModelState.AddModelError(string.Empty, "Login inválido");
                return BadRequest(ModelState);
            }
        }

        private ActionResult<UserTokenViewModel> GenerateToken(LoginViewModel userInfo)
        {
            var claims = new []{
                new Claim("email", userInfo.Email),
                new Claim("meuToken", "token do guilherme"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) 
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddMinutes(20);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: expiration, 
                signingCredentials: creds  
            );

            return new UserTokenViewModel(){
                Token =  new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration,
            };
        }
    }
}