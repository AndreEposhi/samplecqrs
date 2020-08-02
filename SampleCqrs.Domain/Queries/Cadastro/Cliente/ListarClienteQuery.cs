using MediatR;
using SampleCqrs.Domain.Core.Responses;

namespace SampleCqrs.Domain.Queries.Cadastro.Cliente
{
    public class ListarClienteQuery : IRequest<CustomResponse>
    {
    }
}