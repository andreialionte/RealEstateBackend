using MediatR;

namespace RealEstateBackend.Application.Features.Property.Queries.GetProperties
{
    public record GetPropertiesQuery : IRequest<List<Domain.Property>>;
}
