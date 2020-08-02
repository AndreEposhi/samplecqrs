using SampleCqrs.Domain.Interfaces.Repositories.Cadastro;
using SampleCqrs.Domain.Models.Cadastro;
using SampleCqrs.Infra.Data.Contexts;
using System.Linq;

namespace SampleCqrs.Infra.Data.Repositories.Cadastro
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(SampleCqrsDbContext context) : base(context)
        { }

        public Cliente GetByEmail(string email) => Get(filtro => filtro.Email.Equals(email, System.StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
    }
}