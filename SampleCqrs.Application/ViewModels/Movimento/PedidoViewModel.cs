using System;

namespace SampleCqrs.Application.ViewModels.Movimento
{
    public class PedidoViewModel : ViewModelBase
    {
        public int Numero { get; set; }
        public Guid ClienteId { get; set; }
    }
}