namespace ECommerceApp.Application.Features.Addresses.Commands.UpdateAddress
{
    public class UpdateAddressDto
    {
        public Guid AddressId { get; set; }
        public string StreetName { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
