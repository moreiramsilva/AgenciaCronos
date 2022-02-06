##**AgenciaCronos**
#**Tecnologias:**
- .Net Core 6
- MySql **OBS: (Pode-se usar o comando 'Update-Database -Context AgenciaCronosAPIContext' para a criação do BD ou importar os scripts da pasta ScriptsDB)


##**Pacotes instalados:**
- Install-Package Microsoft.EntityFrameworkCore
- Install-Package Microsoft.EntityFrameworkCore.Tools
- Install-Package Pomelo.EntityFrameworkCore.MySql
- Install-Package Microsoft.EntityFrameworkCore.Design


##**Comandos do Migration executados para criação do banco:**
- Add-Migration Alteracao -Context AgenciaCronosAPIContext
- Update-Database -Context AgenciaCronosAPIContext



##**DADOS PARA TESTE**

- Swagger: https://localhost:7223/swagger/index.html

**API SERVIÇO**

- GET: https://localhost:7223/api/Servicos
- POST: https://localhost:7223/api/Servicos
{
  "tituloServico": "Desenvolvimento API",
  "descricao": "Desenvolvimento API em C#",
  "dataInicioServico": "2022-02-06T12:00:00.000Z",
  "dataFimServico": "2022-02-06T23:59:59.999Z"
}
- GET: https://localhost:7223/api/Servicos/1
- PUT: https://localhost:7223/api/Servicos/1
{
  "Id":1,
  "tituloServico": "Desenvolvimento API",
  "descricao": "Desenvolvimento API em C#",
  "dataInicioServico": "2022-02-06T12:00:00.000Z",
  "dataFimServico": "2022-02-08T23:59:59.999Z"
}
- DELETE: https://localhost:7223/api/Servicos/1


**API EQUIPES**

- GET: https://localhost:7223/api/IntegrantesEquipes
- POST: https://localhost:7223/api/IntegrantesEquipes
{
  "tituloEquipe": "Equipe - Desenvolvimento",
  "servicosId": 1
}
- GET: https://localhost:7223/api/IntegrantesEquipes/3
{
  "id": 1,
  "tituloEquipe": "Equipe - Desenvolvimento C#",
  "servicosId": 1
}
- DELETE: https://localhost:7223/api/IntegrantesEquipes/3


**API USUARIOS**

- GET: api/Usuarios
- GET: api/Usuarios/1
POST:
{
  "nome": "Matheus Moreira",
  "papel": "Analista de Sistemas",
  "contato": "matheusms@ymail.com",
  "equipeId":null
}
PUT:
{
  "Id":1,
  "nome": "Matheus Moreira",
  "papel": "Analista de Sistemas",
  "contato": "31996225934",
  "equipeId":1
}
- DELETE: api/Usuarios/1


**API USUARIOS**

- GET: https://localhost:7223/api/Usuarios
- POST:  https://localhost:7223/api/Usuarios
{
  "nome": "Matheus Moreira",
  "papel": "Desenvolvedor",
  "contato": "matheusms@ymail.com",
  "equipeId": 3
}
- GET:  https://localhost:7223/api/Usuarios/1
- PUT:  https://localhost:7223/api/Usuarios/1
{
  "Id":1,
  "nome": "Matheus Moreira",
  "papel": "Desenvolvedor",
  "contato": "matheusms@ymail.com",
  "equipeId": null
}
- DELETE:  https://localhost:7223/api/Usuarios/1

**API POST**

- GET:https://localhost:7223/api/Posts
- POST: https://localhost:7223/api/Posts/
{
  "tituloPost": "Projeto DEV",
  "publicacao": "Projeto de desenvolvimento usando C#",
  "dataPublicacao": "2022-02-06T21:38:59.721Z",
  "criadorId": 1
}
- GET: https://localhost:7223/api/Posts/1
- PUT: https://localhost:7223/api/Posts/1
{
  "id": 1,
  "tituloPost": "Projeto DEV",
  "publicacao": "Projeto de desenvolvimento usando C# e Angular",
  "dataPublicacao": "2022-02-06T21:40:45.529Z",
  "criadorId": 1
}
- DELETE: https://localhost:7223/api/Posts/1