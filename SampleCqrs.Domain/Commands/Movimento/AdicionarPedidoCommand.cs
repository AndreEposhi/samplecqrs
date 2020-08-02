using MediatR;
using SampleCqrs.Domain.Core.Responses;
using SampleCqrs.Domain.Validations.Movimento;
using System;

namespace SampleCqrs.Domain.Commands.Movimento
{
    public class AdicionarPedidoCommand : CommandBase, IRequest<CustomResponse>
    {
        public int Numero { get; private set; }
        public Guid ClienteId { get; private set; }

        public AdicionarPedidoCommand(int numero, Guid clienteId)
        {
            Numero = numero;
            ClienteId = clienteId;
        }

        public override bool EhValido()
        {
            ValidationResult = new AdicionarPedidoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}