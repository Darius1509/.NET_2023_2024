using ECommerceApp.Application.Persistence;
using MediatR;

namespace ECommerceApp.Application.Features.Addresses.Queries.GetById
{
    public class GetByIdAddressQueryHandler : IRequestHandler<GetByIdAddressQuery, AddressDto>
    {
        public readonly IAddressRepository repository;

        public GetByIdAddressQueryHandler(IAddressRepository repository)
        {
            this.repository = repository;
        }

        public async Task<AddressDto> Handle(GetByIdAddressQuery request, CancellationToken cancellationToken)
        {
            var address = await repository.FindByIdAsync(request.Id);
            if (address.IsSuccess)
            {
                return new AddressDto
                {
                    Id = address.Value.AddressId,
                    StreetName = address.Value.StreetName,
                    PostalCode = address.Value.PostalCode,
                    City = address.Value.City,
                    Country = address.Value.Country
                };
            }
            return new AddressDto();
        }
    }
}
