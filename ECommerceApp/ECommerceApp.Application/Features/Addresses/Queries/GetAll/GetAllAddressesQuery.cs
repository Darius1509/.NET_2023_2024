using MediatR;

namespace ECommerceApp.Application.Features.Addresses.Queries.GetAll
{
    public record GetAllAddressesQuery() : IRequest<List<AddressDto>>;
}
