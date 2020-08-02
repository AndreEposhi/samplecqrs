using System;

namespace SampleCqrs.Application.ViewModels
{
    public abstract class ViewModelBase
    {
        public Guid Id { get; set; }
        public DateTime DataCadastro { get; private set; }

        public ViewModelBase()
        {
            DataCadastro = DateTime.Now.Date;
        }
    }
}