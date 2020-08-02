using System;

namespace SampleCqrs.Domain.Models
{
    public abstract class ModelBase
    {
        public DateTime DataCadastro { get; private set; }
        public Guid Id { get; private set; }

        public ModelBase()
        {
            Id = Guid.NewGuid();
            DataCadastro = DateTime.Now.Date;
        }
    }
}