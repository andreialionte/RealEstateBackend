using MediatR;
using RealEstateBackend.Application.Features.Property.Queries.GetProperties;

namespace RealEstateBackend.Application.Features.Property.Queries.GetProperty
{
    public record GetPropertyQuery(int PropertyId) : IRequest<PropertyDto>
    {
    }
}
