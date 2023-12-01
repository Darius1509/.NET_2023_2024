namespace ECommerceApp.Application.Features.Addresses.Commands.DeleteAddress
{
    public class DeleteAddressDto
    {
        public Guid AddressId { get; set; }
        public string StreetName { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
