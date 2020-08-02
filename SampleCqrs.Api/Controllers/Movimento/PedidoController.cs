using SampleCqrs.Application.Interfaces.Movimento;
using SampleCqrs.Application.ViewModels.Movimento;
using System;
using System.Web.Http;

namespace SampleCqrs.Api.Controllers.Movimento
{
    /// <summary>
    /// Controlador do pedido
    /// </summary>
    [RoutePrefix("api/pedido")]
    public class PedidoController : ApiBaseController
    {
        private readonly IPedidoAppService pedidoAppService;

        /// <summary>
        /// Instancia a classe e inicializa as variaáveis
        /// </summary>
        /// <param name="pedidoAppService">Servico de aplicação de pedido</param>
        public PedidoController(IPedidoAppService pedidoAppService)
        {
            this.pedidoAppService = pedidoAppService;
        }

        /// <summary>
        /// Adiociona um pedido
        /// </summary>
        /// <param name="pedidoViewModel">Informações do pedido</param>
        /// <returns></returns>
        [HttpPost]
        [Route("AdicionarPedido")]
        public IHttpActionResult AdicionarPedido(PedidoViewModel pedidoViewModel)
            => GetCustomResponse(pedidoAppService.AdicionarPedido(pedidoViewModel).Result);
    }
}