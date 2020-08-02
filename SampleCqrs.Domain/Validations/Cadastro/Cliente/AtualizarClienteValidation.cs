using SampleCqrs.Domain.Commands.Cadastro.Cliente;

namespace SampleCqrs.Domain.Validations.Cadastro.Cliente
{
    public class AtualizarClienteValidation : ClienteValidationBase<AtualizarClienteCommand>
    {
        public AtualizarClienteValidation()
        {
            ValidarId();
            ValidarNome();
            ValidarEmail();
        }
    }
}