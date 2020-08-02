using SampleCqrs.Domain.Validations.Cadastro.Cliente;
using System;

namespace SampleCqrs.Domain.Commands.Cadastro.Cliente
{
    public class AdicionarClienteCommand : ClienteCommand
    {
        public AdicionarClienteCommand(string nome, string email) : base(nome, email)
        { }

        public override bool EhValido()
        {
            ValidationResult = new AdicionarClienteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}