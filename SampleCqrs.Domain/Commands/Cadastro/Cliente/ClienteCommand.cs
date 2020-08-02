using MediatR;
using SampleCqrs.Domain.Core.Responses;
using System;

namespace SampleCqrs.Domain.Commands.Cadastro.Cliente
{
    public abstract class ClienteCommand : CommandBase, IRequest<CustomResponse>
    {
        public string Nome { get; set; }
        public string Email { get; set; }

        protected ClienteCommand(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }
    }
}