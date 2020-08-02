using MediatR;
using SampleCqrs.Domain.Commands.Cadastro.Cliente;
using SampleCqrs.Domain.Core.Enums.Responses;
using SampleCqrs.Domain.Core.Responses;
using SampleCqrs.Domain.Interfaces.Repositories.Cadastro;
using SampleCqrs.Domain.Interfaces.UnitOfWork;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SampleCqrs.Domain.Commands.Handlers.Cadastro.Cliente
{
    public class RemoverClienteHandler : IRequestHandler<RemoverClienteCommand, CustomResponse>
    {
        private readonly IClienteRepository clienteRepository;
        private readonly IUnitOfWork unitOfWork;
        public RemoverClienteHandler(IClienteRepository clienteRepository, IUnitOfWork unitOfWork)
        {
            this.clienteRepository = clienteRepository;
            this.unitOfWork = unitOfWork;
        }

        public Task<CustomResponse> Handle(RemoverClienteCommand command, CancellationToken cancellationToken)
        {
            var respostaCustomizada = new CustomResponse();

            if (!command.EhValido())
            {
                var erros = new List<string>();

                foreach (var erro in command.ValidationResult.Errors)
                    erros.Add(erro.ErrorMessage);

                respostaCustomizada.AdicionarErro(erros);

                return Task.FromResult(respostaCustomizada);
            }

            var cliente = clienteRepository.GetById(command.Id);

            if (cliente == null)
            {
                respostaCustomizada = new CustomResponse(mensagem: "Erro ao remover.");
                respostaCustomizada.AdicionarErro(new List<string> { "Cliente não existe." });

                return Task.FromResult(respostaCustomizada);
            }

            clienteRepository.Remove(cliente.Id);

            if (!unitOfWork.Commit())
            {
                respostaCustomizada = new CustomResponse(mensagem: "Erro ao remover.");
                respostaCustomizada.AdicionarErro(new List<string> { "Erro ao remover o cliente." });

                return Task.FromResult(respostaCustomizada);
            }

            respostaCustomizada = new CustomResponse(ResponseStatus.Sucesso, "Cliente removido com sucesso.");
            return Task.FromResult(respostaCustomizada);
        }
    }
}