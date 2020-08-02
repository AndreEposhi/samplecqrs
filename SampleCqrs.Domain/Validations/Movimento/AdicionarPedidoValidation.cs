using FluentValidation;
using SampleCqrs.Domain.Commands.Movimento;
using System;

namespace SampleCqrs.Domain.Validations.Movimento
{
    public class AdicionarPedidoValidation : ValidationBase<AdicionarPedidoCommand>
    {
        public AdicionarPedidoValidation()
        {
            ValidarNumero();
            ValidarClienteId();
        }

        protected void ValidarNumero()
        {
            RuleFor(rule => rule.Numero)
                .GreaterThanOrEqualTo(0).WithMessage("Numero do pedido inválido.");
        }

        protected void ValidarClienteId()
        {
            RuleFor(rule => rule.ClienteId)
                .NotEqual(Guid.Empty).WithMessage("Cliente inválido.");
        }
    }
}