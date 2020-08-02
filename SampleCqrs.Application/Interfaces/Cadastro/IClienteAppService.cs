using SampleCqrs.Application.ViewModels.Cadastro;
using SampleCqrs.Domain.Core.Responses;
using System;
using System.Threading.Tasks;

namespace SampleCqrs.Application.Interfaces.Cadastro
{
    public interface IClienteAppService
    {
        Task<CustomResponse> AdicionarCliente(ClienteViewModel clienteViewModel);

        Task<CustomResponse> AtualizarCliente(ClienteViewModel clienteViewModel);

        Task<CustomResponse> RemoverCliente(Guid id);

        Task<CustomResponse> ObterClientePorId(Guid id);

        Task<CustomResponse> ListarCliente();
    }
}