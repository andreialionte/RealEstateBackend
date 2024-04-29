using AutoMapper;
using MediatR;
using RealEstateBackend.Application.Contracts.Persistence;
using Serilog;

namespace RealEstateBackend.Application.Features.Property.Commands.UpdateProperty
{
    public class UpdatePropertyCommandHandler : IRequestHandler<UpdatePropertyCommand, Unit>
    {
        private readonly ILogger _logger;
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;

        public UpdatePropertyCommandHandler(ILogger logger, IPropertyRepository propertyRepository, IMapper mapper)
        {
            _logger = logger;
            _propertyRepository = propertyRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePropertyCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdatePropertyCommandValidator();
            var validatorResult = await validator.ValidateAsync(request);
            if (!validatorResult.IsValid)
            {
                _logger.Error("UpdatePropertyCommandHandler validation failed for property {@Property}", request);
            }
            var getProperty = await _propertyRepository.GetByIdAsync(request.Id);

            _mapper.Map(request.Property, getProperty);


            await _propertyRepository.UpdateAsync(getProperty);
            return Unit.Value;
        }
    }
}
//next sa facem cel de imagine cu AWS S3
//dupa sa facem auth si user 
//si dupa astea vine Review sau un SendGrid email sender dupa ce iti faci cont;