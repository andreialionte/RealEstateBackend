using MediatR;
using RealEstateBackend.Application.Features.Property.Queries.GetProperties;

namespace RealEstateBackend.Application.Features.Property.Commands.CreateProperty
{
    public record CreatePropertyCommand(PropertyDto PropertyDto) : IRequest<int>;
}
