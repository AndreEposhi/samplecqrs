using SampleCqrs.Domain.Commands.Cadastro.Cliente;

namespace SampleCqrs.Domain.Validations.Cadastro.Cliente
{
    public class AdicionarClienteValidation : ClienteValidationBase<AdicionarClienteCommand>
    {
        public AdicionarClienteValidation()
        {
            ValidarNome();
            ValidarEmail();
        }
    }
}