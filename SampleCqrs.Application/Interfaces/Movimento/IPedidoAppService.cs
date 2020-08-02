using SampleCqrs.Application.ViewModels.Movimento;
using SampleCqrs.Domain.Core.Responses;
using System.Threading.Tasks;

namespace SampleCqrs.Application.Interfaces.Movimento
{
    public interface IPedidoAppService
    {
        Task<CustomResponse> AdicionarPedido(PedidoViewModel pedidoViewModel);
    }
}