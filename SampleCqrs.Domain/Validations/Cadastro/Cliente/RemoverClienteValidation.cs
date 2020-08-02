using SampleCqrs.Domain.Commands.Cadastro.Cliente;

namespace SampleCqrs.Domain.Validations.Cadastro.Cliente
{
    public class RemoverClienteValidation : ClienteValidationBase<RemoverClienteCommand>
    {
        public RemoverClienteValidation()
        {
            ValidarId();
        }
    }
}