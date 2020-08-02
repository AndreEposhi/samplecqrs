using SampleCqrs.Domain.Models.Movimento;
using System.Collections.Generic;

namespace SampleCqrs.Domain.Models.Cadastro
{
    public class Cliente : ModelBase
    {
        public string Email { get; private set; }

        public string Nome { get; private set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }

        protected Cliente()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public Cliente(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        public void ChangeInformation(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }
    }
}