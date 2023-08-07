# TesteApiIdentityAuth
Esse é um repositório de estudos de Web API do .NET Core 7.0 utilizando o EntityFramework, SQL Server e o Identity para a criação de um CRUD básico com proteção dos Endpoints da API para usuários não cadastrados e logados no sistema.<br>
---

# INSTRUÇÕES PARA PRIMEIRA EXECUÇÃO
<p>
No VS Code:<br>
 1. <strong>`dotnet restore .\APIRelacionamento.csproj`</strong> na pasta principal do projeto para restaurar as dependências utilizadas. <br>
 2. Utilizar o <strong>`dotnet tool update --global dotnet-ef`</strong> e depois <strong>`dotnet ef database update`</strong> para rodar a migration existente no projeto num novo repositóorio. <br>
 3. <strong>`dotnet run`</strong> para executar o projeto <br> 
 4. Utilizar o <strong>`localhost:XXXX/swagger`</strong> para abrir visualização com o swagger. <br>
 5. Criar Usuário na rota <strong>CreateUser</strong>. A senha deve conter <strong>Letras maiúsculas, minúsculas, números e elementos não-alfanumericos</strong><br>
 6. Copiar e colar o Token gerado na aba <strong>Authorize</strong> com a sintaxe <strong>"Bearer + Token Gerado"</strong>
</p>
