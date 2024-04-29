using AutoMapper;
using MediatR;
using RealEstateBackend.Application.Contracts.Persistence;
using RealEstateBackend.Application.Features.Property.Queries.GetProperties;
using Serilog;

namespace RealEstateBackend.Application.Features.Property.Queries.GetProperty
{
    public class GetPropertyQueryHandler : IRequestHandler<GetPropertyQuery, PropertyDto>
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public GetPropertyQueryHandler(ILogger logger, IPropertyRepository propertyRepository, IMapper mapper)
        {
            _propertyRepository = propertyRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<PropertyDto> Handle(GetPropertyQuery request, CancellationToken cancellationToken)
        {
            var property = await _propertyRepository.GetByIdAsync(request.PropertyId);
            if (property == null)
            {
                _logger.Error($"This {property.Id} dosent exist.");
            }
            var data = _mapper.Map<PropertyDto>(property);
            _logger.Information("The @Property was added to the db!");

            return data;
        }
    }
}
