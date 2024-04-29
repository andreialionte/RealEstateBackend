using MediatR;

namespace RealEstateBackend.Application.Features.Property.Commands.DeleteProperty
{
    public record DeletePropertyCommand(int PropertyId) : IRequest<Unit>;
}
