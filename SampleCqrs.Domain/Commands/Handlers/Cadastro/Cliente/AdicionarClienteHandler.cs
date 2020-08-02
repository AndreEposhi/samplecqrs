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
    public class AdicionarClienteHandler : IRequestHandler<AdicionarClienteCommand, CustomResponse>
    {
        private readonly IClienteRepository clienteRepository;
        private readonly IUnitOfWork unitOfWork;
        public AdicionarClienteHandler(IClienteRepository clienteRepository, IUnitOfWork unitOfWork)
        {
            this.clienteRepository = clienteRepository;
            this.unitOfWork = unitOfWork;
        }

        public Task<CustomResponse> Handle(AdicionarClienteCommand command, CancellationToken cancellationToken)
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

            if (clienteRepository.GetByEmail(command.Email) != null)
            {
                respostaCustomizada.AdicionarErro(new List<string> { $"Já existe cliente com este e-mail: {command.Email}." });

                return Task.FromResult(respostaCustomizada);
            }

            var cliente = new Models.Cadastro.Cliente(command.Nome, command.Email);
            clienteRepository.Add(cliente);

            if (!unitOfWork.Commit())
            {
                respostaCustomizada = new CustomResponse(mensagem: "Erro ao salvar.");
                respostaCustomizada.AdicionarErro(new List<string> { "Ocorreu um erro ao salvar o cliente." });

                return Task.FromResult(respostaCustomizada);
            }

            respostaCustomizada = new CustomResponse(ResponseStatus.Sucesso, "Cliente cadastrado com sucesso.");
            return Task.FromResult(respostaCustomizada);
        }
    }
}