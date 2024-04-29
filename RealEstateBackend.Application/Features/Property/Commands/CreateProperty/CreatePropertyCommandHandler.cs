using AutoMapper;
using MediatR;
using RealEstateBackend.Application.Contracts.Persistence;
using Serilog;

namespace RealEstateBackend.Application.Features.Property.Commands.CreateProperty
{
    public class CreatePropertyCommandHandler : IRequestHandler<CreatePropertyCommand, int>
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CreatePropertyCommandHandler(IPropertyRepository propertyRepository, IMapper mapper, ILogger logger)
        {
            _propertyRepository = propertyRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<int> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatePropertyCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);
            if (!validatorResult.IsValid)
            {
                _logger.Error("CreatePropertyCommandHandler validation failed for property {@Property}", request);
            }
            var property = _mapper.Map<Domain.Property>(request.PropertyDto); //create the entity
            await _propertyRepository.CreateAsync(property);
            return property.Id;
        }
    }
}
