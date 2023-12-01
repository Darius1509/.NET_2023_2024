namespace ECommerceApp.Application.Features.Addresses.Queries
{
    public class AddressDto
    {
        public Guid AddressId { get; set; }
        public string StreetName { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
