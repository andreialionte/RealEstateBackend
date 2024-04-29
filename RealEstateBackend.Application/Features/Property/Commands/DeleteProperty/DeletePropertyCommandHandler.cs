using MediatR;
using RealEstateBackend.Application.Contracts.Persistence;
using Serilog;

namespace RealEstateBackend.Application.Features.Property.Commands.DeleteProperty
{
    public class DeletePropertyCommandHandler : IRequestHandler<DeletePropertyCommand, Unit>
    {
        private readonly ILogger _logger;
        private readonly IPropertyRepository _propertyRepository;

        public DeletePropertyCommandHandler(ILogger logger, IPropertyRepository propertyRepository)
        {
            _logger = logger;
            _propertyRepository = propertyRepository;
        }

        public async Task<Unit> Handle(DeletePropertyCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeletePropertyCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);
            if (!validatorResult.IsValid)
            {
                _logger.Error("DeletePropertyCommandHandler validation failed for property {@Property}", request);
            }
            var property = await _propertyRepository.GetByIdAsync(request.PropertyId);
            await _propertyRepository.DeleteAsync(property);

            return Unit.Value;
        }
    }
}
