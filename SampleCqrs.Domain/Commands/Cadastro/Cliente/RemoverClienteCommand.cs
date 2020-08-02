using SampleCqrs.Domain.Validations.Cadastro.Cliente;
using System;

namespace SampleCqrs.Domain.Commands.Cadastro.Cliente
{
    public class RemoverClienteCommand : ClienteCommand
    {
        public RemoverClienteCommand(Guid id, string nome, string email) : base(nome, email)
        {
            Id = id;
        }

        public override bool EhValido()
        {
            ValidationResult = new RemoverClienteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}