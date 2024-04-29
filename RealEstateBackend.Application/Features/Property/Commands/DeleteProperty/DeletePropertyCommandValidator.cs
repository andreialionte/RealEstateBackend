using FluentValidation;

namespace RealEstateBackend.Application.Features.Property.Commands.DeleteProperty
{
    public class DeletePropertyCommandValidator : AbstractValidator<DeletePropertyCommand>
    {
        public DeletePropertyCommandValidator()
        {
            RuleFor(p => p.PropertyId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
