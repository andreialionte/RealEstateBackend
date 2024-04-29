using AutoMapper;
using RealEstateBackend.Application.Features.Property.Commands.CreateProperty;
using RealEstateBackend.Application.Features.Property.Queries.GetProperties;

namespace RealEstateBackend.Application.MappingProfiles
{
    public class PropertryProfile : Profile
    {

        public PropertryProfile()
        {
            CreateMap<CreatePropertyCommand, Domain.Property>();
            CreateMap<Domain.Property, PropertyDto>().ReverseMap();
            /*            CreateMap<UpdatePropertyCommand, Domain.Property>();*/
        }
    }
}
