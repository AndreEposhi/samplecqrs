using MediatR;
using SampleCqrs.Application.Interfaces.Cadastro;
using SampleCqrs.Application.ViewModels.Cadastro;
using SampleCqrs.Domain.Commands.Cadastro.Cliente;
using SampleCqrs.Domain.Core.Responses;
using SampleCqrs.Domain.Queries.Cadastro.Cliente;
using System;
using System.Threading.Tasks;
using Map = AutoMapper;

namespace SampleCqrs.Application.Services.Cadastro
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IMediator mediator;

        public ClienteAppService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public Task<CustomResponse> AdicionarCliente(ClienteViewModel clienteViewModel)
        {
            var adicionarClienteCommand = Map.Mapper.Map<AdicionarClienteCommand>(clienteViewModel);

            return mediator.Send(adicionarClienteCommand);
        }

        public Task<CustomResponse> AtualizarCliente(ClienteViewModel clienteViewModel)
        {
            var atualizarClienteCommand = Map.Mapper.Map<AtualizarClienteCommand>(clienteViewModel);

            return mediator.Send(atualizarClienteCommand);
        }

        public Task<CustomResponse> RemoverCliente(Guid id) => mediator.Send(new RemoverClienteCommand(id, "", ""));

        public Task<CustomResponse> ObterClientePorId(Guid id) => mediator.Send(new ObterClientePorIdQuery(id));

        public Task<CustomResponse> ListarCliente() => mediator.Send(new ListarClienteQuery());
    }
}