using FluentValidation.Results;
using System;

namespace SampleCqrs.Domain.Commands
{
    public abstract class CommandBase
    {
        public Guid Id { get; protected set; }
        public DateTime DataCadastro { get; private set; }

        public ValidationResult ValidationResult { get; set; }

        protected CommandBase()
        {
            DataCadastro = DateTime.Now.Date;
        }

        public abstract bool EhValido();
    }
}