using MediatR;
using SampleCqrs.Application.Interfaces.Movimento;
using SampleCqrs.Application.ViewModels.Movimento;
using SampleCqrs.Domain.Commands.Movimento;
using SampleCqrs.Domain.Core.Responses;
using System.Threading.Tasks;
using Map = AutoMapper;

namespace SampleCqrs.Application.Services.Movimento
{
    public class PedidoAppService : IPedidoAppService
    {
        private readonly IMediator mediator;

        public PedidoAppService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public Task<CustomResponse> AdicionarPedido(PedidoViewModel pedidoViewModel)
            => mediator.Send(Map.Mapper.Map<AdicionarPedidoCommand>(pedidoViewModel));
    }
}