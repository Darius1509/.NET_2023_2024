namespace ECommerceApp.Application.Features.Addresses.Commands.CreateAddress
{
    public class CreateAddressDto
    {
        public Guid Id { get; set; }
        public string StreetName { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
