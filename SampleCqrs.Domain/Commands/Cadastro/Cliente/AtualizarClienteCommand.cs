using SampleCqrs.Domain.Validations.Cadastro.Cliente;
using System;

namespace SampleCqrs.Domain.Commands.Cadastro.Cliente
{
    public class AtualizarClienteCommand : ClienteCommand
    {
        public AtualizarClienteCommand(Guid id, string nome, string email) : base(nome, email)
        {
            Id = id;
        }

        public override bool EhValido()
        {
            ValidationResult = new AtualizarClienteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}