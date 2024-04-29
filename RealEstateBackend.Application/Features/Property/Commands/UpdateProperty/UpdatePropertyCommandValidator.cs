using FluentValidation;

namespace RealEstateBackend.Application.Features.Property.Commands.UpdateProperty
{
    public class UpdatePropertyCommandValidator : AbstractValidator<UpdatePropertyCommand>
    {
        public UpdatePropertyCommandValidator()
        {

            RuleFor(p => p.Id).NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().GreaterThan(0);
        }
    }
}
