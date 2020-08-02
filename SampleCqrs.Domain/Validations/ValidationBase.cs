using FluentValidation;
using SampleCqrs.Domain.Commands;
using System;

namespace SampleCqrs.Domain.Validations
{
    public abstract class ValidationBase<TCommand> : AbstractValidator<TCommand>
        where TCommand : CommandBase
    {
        protected void ValidarId()
        {
            RuleFor(rule => rule.Id).NotEqual(Guid.Empty);
        }
    }
}