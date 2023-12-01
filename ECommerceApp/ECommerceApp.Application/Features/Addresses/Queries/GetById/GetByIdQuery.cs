using MediatR;

namespace ECommerceApp.Application.Features.Addresses.Queries.GetById
{
    public record GetByIdAddressQuery(Guid Id) : IRequest<AddressDto>;
}
