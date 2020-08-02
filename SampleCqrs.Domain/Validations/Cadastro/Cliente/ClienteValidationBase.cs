using FluentValidation;
using SampleCqrs.Domain.Commands.Cadastro.Cliente;

namespace SampleCqrs.Domain.Validations.Cadastro.Cliente
{
    public abstract class ClienteValidationBase<TCommand> : ValidationBase<TCommand>
        where TCommand : ClienteCommand
    {
        protected void ValidarNome()
        {
            RuleFor(rule => rule.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .Length(2, 200).WithMessage("O nome deve conter no mínimo duas letras ou no máximo duzentas.");
        }

        protected void ValidarEmail()
        {
            RuleFor(rule => rule.Email)
                .NotEmpty().WithMessage("E-mail é obrigatório.")
                .EmailAddress();
        }
    }
}