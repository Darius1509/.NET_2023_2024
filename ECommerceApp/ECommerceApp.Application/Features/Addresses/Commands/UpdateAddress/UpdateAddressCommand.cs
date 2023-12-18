using MediatR;

namespace ECommerceApp.Application.Features.Addresses.Commands.UpdateAddress
{
    public class UpdateAddressCommand : IRequest<UpdateAddressCommandResponse>
    {
        public Guid Id { get; set; }
        public string StreetName { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
