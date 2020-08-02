using SampleCqrs.Api.Security.Jwt;
using SampleCqrs.Domain.Core.Enums.Responses;
using SampleCqrs.Domain.Core.Responses;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace SampleCqrs.Api.Controllers.Registro
{
    /// <summary>
    /// Controlador de autenticação na aplicação
    /// </summary>
    [RoutePrefix("api/autenticacao")]
    public class AutenticacaoController : ApiBaseController
    {
        /// <summary>
        /// Faz a autenticação do usuário
        /// </summary>
        /// <param name="login">Login do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Logar")]
        public IHttpActionResult Logar(string login, string senha)
        {
            var respostaCustomizada = new CustomResponse();

            if (login.Equals("admin", StringComparison.InvariantCultureIgnoreCase) &&
                senha.Equals("1234", StringComparison.InvariantCultureIgnoreCase))
            {
                respostaCustomizada = new CustomResponse(ResponseStatus.Sucesso, "Login efetuado com sucesso.");
                respostaCustomizada.AdicionarDado(new List<object> { TokenManager.GenerateToken(login) });
                return GetCustomResponse(respostaCustomizada);
            }
            else
            {
                respostaCustomizada = new CustomResponse(mensagem: "Erro ao logar");
                respostaCustomizada.AdicionarErro(new List<string> { "Usuário ou senha inválidos" });
                return GetCustomResponse(respostaCustomizada);
            }
        }
    }
}