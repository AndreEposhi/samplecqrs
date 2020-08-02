using SampleCqrs.Domain.Models.Cadastro;
using System;

namespace SampleCqrs.Domain.Models.Movimento
{
    public class Pedido : ModelBase
    {
        protected Pedido()
        { }

        public Pedido(int numero, Guid clienteId)
        {
            Numero = numero;
            ClienteId = clienteId;
        }

        public int Numero { get; private set; }

        public Guid ClienteId { get; private set; }

        public virtual Cliente Cliente { get; set; }
    }
}