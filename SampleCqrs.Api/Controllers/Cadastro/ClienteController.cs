using SampleCqrs.Api.Security.Authentications.Attributes;
using SampleCqrs.Application.Interfaces.Cadastro;
using SampleCqrs.Application.ViewModels.Cadastro;
using System;
using System.Web.Http;

namespace SampleCqrs.Api.Controllers.Cadastro
{
    /// <summary>
    /// Controller da entida de cliente
    /// </summary>
    [RoutePrefix("api/cliente")]
    public class ClienteController : ApiBaseController
    {
        private readonly IClienteAppService clienteAppService;

        /// <summary>
        /// Instancia a classe e inicializa as variáveis
        /// </summary>
        /// <param name="clienteAppService">servico de aplicação de cliente</param>
        public ClienteController(IClienteAppService clienteAppService)
        {
            this.clienteAppService = clienteAppService;
        }

        /// <summary>
        /// Adiciona um cliente
        /// </summary>
        /// <param name="clienteViewModel">Informações do cliente</param>
        /// <returns></returns>
        [HttpPost]
        [Route("AdicionarCliente")]
        public IHttpActionResult AdicionarCliente([FromBody] ClienteViewModel clienteViewModel)
            => GetCustomResponse(clienteAppService.AdicionarCliente(clienteViewModel).Result);

        /// <summary>
        /// Atualiza as informações do cliente
        /// </summary>
        /// <param name="clienteViewModel">Informações do cliente</param>
        /// <returns></returns>
        [HttpPut]
        [Route("AtualizarCliente")]
        public IHttpActionResult AtualizarCliente([FromBody] ClienteViewModel clienteViewModel)
            => GetCustomResponse(clienteAppService.AtualizarCliente(clienteViewModel).Result);

        /// <summary>
        /// Remove um cliente pelo identificador
        /// </summary>
        /// <param name="id">Identificador do cliente</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("RemoverCliente")]
        public IHttpActionResult RemoverCliente(Guid id)
            => GetCustomResponse(clienteAppService.RemoverCliente(id).Result);

        /// <summary>
        /// Obtem um cliente pelo identificador
        /// </summary>
        /// <param name="id">Identificador do cliente</param>
        /// <returns></returns>
        [HttpGet]
        [Route("ObterClientePorId")]
        public IHttpActionResult ObterClientePorId(Guid id)
            => GetCustomResponse(clienteAppService.ObterClientePorId(id).Result);

        /// <summary>
        /// Lista todos os clientes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ListarCliente")]
        [Authorization]
        public IHttpActionResult ListarCliente()
            => GetCustomResponse(clienteAppService.ListarCliente().Result);
    }
}