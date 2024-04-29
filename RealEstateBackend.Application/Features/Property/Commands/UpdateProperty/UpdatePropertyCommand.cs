using MediatR;
using RealEstateBackend.Application.Features.Property.Queries.GetProperties;

namespace RealEstateBackend.Application.Features.Property.Commands.UpdateProperty
{
    public record UpdatePropertyCommand(int Id, PropertyDto Property) : IRequest<Unit>
    {
    }
}
