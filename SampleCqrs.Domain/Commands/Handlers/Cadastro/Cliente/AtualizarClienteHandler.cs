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
    public class AtualizarClienteHandler : IRequestHandler<AtualizarClienteCommand, CustomResponse>
    {
        private readonly IClienteRepository clienteRepository;
        private readonly IUnitOfWork unitOfWork;

        public AtualizarClienteHandler(IClienteRepository clienteRepository, IUnitOfWork unitOfWork)
        {
            this.clienteRepository = clienteRepository;
            this.unitOfWork = unitOfWork;
        }

        public Task<CustomResponse> Handle(AtualizarClienteCommand command, CancellationToken cancellationToken)
        {
            var respostaCustomizada = new CustomResponse();

            if (!command.EhValido())
            {
                var errosDeValidacao = new List<string>();

                foreach (var erro in command.ValidationResult.Errors)
                    errosDeValidacao.Add(erro.ErrorMessage);

                respostaCustomizada.AdicionarErro(errosDeValidacao);

                return Task.FromResult(respostaCustomizada);
            }

            var cliente = clienteRepository.GetById(command.Id);

            if (cliente == null)
            {
                respostaCustomizada.AdicionarErro(new List<string> { "Cliente não cadastrado." });

                return Task.FromResult(respostaCustomizada);
            }

            cliente.ChangeInformation(command.Nome, command.Email);
            clienteRepository.Update(cliente);

            if (!unitOfWork.Commit())
            {
                respostaCustomizada = new CustomResponse(mensagem: "Erro ao atualizar.");
                respostaCustomizada.AdicionarErro(new List<string> { "Ocorreu um erro ao atualizar o cliente." });

                return Task.FromResult(respostaCustomizada);
            }

            respostaCustomizada = new CustomResponse(ResponseStatus.Sucesso, "Cliente atualizado com sucesso.");
            return Task.FromResult(respostaCustomizada);
        }
    }
}