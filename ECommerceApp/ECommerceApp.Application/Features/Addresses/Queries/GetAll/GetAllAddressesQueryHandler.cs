using ECommerceApp.Application.Persistence;
using MediatR;

namespace ECommerceApp.Application.Features.Addresses.Queries.GetAll
{
    public class GetAllAddressesQueryHandler : IRequestHandler<GetAllAddressesQuery, List<AddressDto>>
    {
        private readonly IAddressRepository repository;
        
        public GetAllAddressesQueryHandler(IAddressRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<AddressDto>> Handle(GetAllAddressesQuery request, CancellationToken cancellationToken)
        {
            var addresses = await repository.GetAllAsync();
            var listOfAddresses = new List<AddressDto>();

            foreach (var address in addresses.Value)
            {
                listOfAddresses.Add(new AddressDto
                {
                    AddressId = address.AddressId,
                    StreetName = address.StreetName,
                    PostalCode = address.PostalCode,
                    City = address.City,
                    Country = address.Country
                });
            }

            return listOfAddresses;
        }
    }
}
