using MediatR;

namespace ECommerceApp.Application.Features.Addresses.Commands.CreateAddress
{
    public class CreateAddressCommand : IRequest<CreateAddressCommandResponse>
    {
        public Guid AddressId { get; set; }
        public string StreetName { get; set; } 
        public int PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
