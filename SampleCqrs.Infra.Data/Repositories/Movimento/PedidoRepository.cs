using SampleCqrs.Domain.Interfaces.Repositories.Movimento;
using SampleCqrs.Domain.Models.Movimento;
using SampleCqrs.Infra.Data.Contexts;

namespace SampleCqrs.Infra.Data.Repositories.Movimento
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(SampleCqrsDbContext context) : base(context)
        { }
    }
}