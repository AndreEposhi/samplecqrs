using MediatR;
using SampleCqrs.Domain.Core.Enums.Responses;
using SampleCqrs.Domain.Core.Responses;
using SampleCqrs.Domain.Interfaces.Repositories.Cadastro;
using SampleCqrs.Domain.Queries.Cadastro.Cliente;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SampleCqrs.Domain.Queries.Handlers.Cadastro.Cliente
{
    public class ListarClienteHandler : IRequestHandler<ListarClienteQuery, CustomResponse>
    {
        private readonly IClienteRepository clienteRepository;

        public ListarClienteHandler(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        public Task<CustomResponse> Handle(ListarClienteQuery request, CancellationToken cancellationToken)
        {
            var respostaCustomizada = new CustomResponse();
            var clientes = clienteRepository.GetAll();

            if (!clientes.Any())
            {
                respostaCustomizada = new CustomResponse(mensagem: "Erro ao consultar");
                respostaCustomizada.AdicionarErro(new List<string> { "Não há clientes." });

                return Task.FromResult(respostaCustomizada);
            }

            respostaCustomizada = new CustomResponse(ResponseStatus.Sucesso, "Consultar clientes.");
            respostaCustomizada.AdicionarDado(new List<object>
            {
                clientes
            });

            return Task.FromResult(respostaCustomizada);
        }
    }
}