using MediatR;
using SampleCqrs.Domain.Commands.Movimento;
using SampleCqrs.Domain.Core.Enums.Responses;
using SampleCqrs.Domain.Core.Responses;
using SampleCqrs.Domain.Interfaces.Repositories.Movimento;
using SampleCqrs.Domain.Interfaces.UnitOfWork;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SampleCqrs.Domain.Commands.Handlers.Movimento
{
    public class AdicionarPedidoHandler : IRequestHandler<AdicionarPedidoCommand, CustomResponse>
    {
        private readonly IPedidoRepository pedidoRepository;
        private readonly IUnitOfWork unitOfWork;

        public AdicionarPedidoHandler(IPedidoRepository pedidoRepository,
                                      IUnitOfWork unitOfWork)
        {
            this.pedidoRepository = pedidoRepository;
            this.unitOfWork = unitOfWork;
        }

        public Task<CustomResponse> Handle(AdicionarPedidoCommand command, CancellationToken cancellationToken)
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

            var pedido = new Models.Movimento.Pedido(command.Numero, command.ClienteId);
            pedidoRepository.Add(pedido);

            if (!unitOfWork.Commit())
            {
                respostaCustomizada = new CustomResponse(mensagem: "Erro ao adicionar.");
                respostaCustomizada.AdicionarErro(new List<string> { "Erro ao adicionar o pedido." });

                return Task.FromResult(respostaCustomizada);
            }

            respostaCustomizada = new CustomResponse(ResponseStatus.Sucesso, "Pedido cadastrado com sucesso.");
            return Task.FromResult(respostaCustomizada);
        }
    }
}