using MediatR;
using SampleCqrs.Domain.Core.Responses;
using System;

namespace SampleCqrs.Domain.Queries.Cadastro.Cliente
{
    public class ObterClientePorIdQuery : IRequest<CustomResponse>
    {
        public ObterClientePorIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}