using Newtonsoft.Json;
using SampleCqrs.Application.ViewModels.Movimento;
using System.Collections.Generic;

namespace SampleCqrs.Application.ViewModels.Cadastro
{
    public class ClienteViewModel : ViewModelBase
    {
        public ClienteViewModel()
        {
            Pedidos = new List<PedidoViewModel>();
        }
        public string Nome { get; set; }
        public string Email { get; set; }

        [JsonIgnore]
        public virtual ICollection<PedidoViewModel> Pedidos { get; set; }
    }
}