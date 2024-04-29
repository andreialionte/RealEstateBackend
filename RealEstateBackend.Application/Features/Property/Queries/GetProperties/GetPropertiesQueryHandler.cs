using AutoMapper;
using MediatR;
using RealEstateBackend.Application.Contracts.Persistence;

namespace RealEstateBackend.Application.Features.Property.Queries.GetProperties
{
    public class GetPropertiesQueryHandler : IRequestHandler<GetPropertiesQuery, List<Domain.Property>>
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;
        public GetPropertiesQueryHandler(IPropertyRepository propertyRepository, IMapper mapper)
        {
            _propertyRepository = propertyRepository;
            _mapper = mapper;
        }
        public async Task<List<Domain.Property>> Handle(GetPropertiesQuery request, CancellationToken cancellationToken)
        {
            var properties = await _propertyRepository.GetAllAsync();
            // decouple your domain model from your presentation layer.
            //mereu sa ferim exact datele reale si sa folosim un DTO

            //este o practică bună să folosești DTO-uri (Data Transfer Objects)
            //pentru a separa modelul de date al aplicației tale (entitățile din domeniu)
            //de modelul de date folosit în interfețele de utilizator sau în operațiile de citire

            //DTO-urile in clean arhitecture si cqrs
            //pot fi folosite pentru a transmite doar informațiile necesare către client
            //fără a expune întreaga structură a entităților de domeniu.

            var data = _mapper.Map<List<Domain.Property>>(properties);

            return data;
        }
    }

}
