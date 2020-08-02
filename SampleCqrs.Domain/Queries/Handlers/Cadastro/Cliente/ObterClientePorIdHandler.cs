using MediatR;
using SampleCqrs.Domain.Core.Responses;
using SampleCqrs.Domain.Interfaces.Repositories.Cadastro;
using SampleCqrs.Domain.Queries.Cadastro.Cliente;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SampleCqrs.Domain.Queries.Handlers.Cadastro.Cliente
{
    public class ObterClientePorIdHandler : IRequestHandler<ObterClientePorIdQuery, CustomResponse>
    {
        private readonly IClienteRepository clienteRepository;

        public ObterClientePorIdHandler(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        public Task<CustomResponse> Handle(ObterClientePorIdQuery request, CancellationToken cancellationToken)
        {
            var respostaCustomizada = new CustomResponse();

            var cliente = clienteRepository.GetById(request.Id);

            if (cliente == null)
            {
                respostaCustomizada = new CustomResponse(mensagem: "Erro ao pesquisar.");
                respostaCustomizada.AdicionarErro(new List<string> { "Cliente não localizado." });

                return Task.FromResult(respostaCustomizada);
            }

            respostaCustomizada = new CustomResponse(Core.Enums.Responses.ResponseStatus.Sucesso, "Cliente");
            respostaCustomizada.AdicionarDado(new List<object>
            {
                cliente
            });

            return Task.FromResult(respostaCustomizada);
        }
    }
}