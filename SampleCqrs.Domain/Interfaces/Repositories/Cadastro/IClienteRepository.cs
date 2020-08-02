using SampleCqrs.Domain.Models.Cadastro;

namespace SampleCqrs.Domain.Interfaces.Repositories.Cadastro
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Cliente GetByEmail(string email);
    }
}