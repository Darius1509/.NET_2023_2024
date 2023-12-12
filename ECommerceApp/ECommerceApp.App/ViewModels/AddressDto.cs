namespace ECommerceApp.App.ViewModels
{
    public class AddressDto
    {
        public Guid AddressId { get; set; }
        public string StreetName { get; set; } = string.Empty;
        public int PostalCode { get; set; }
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }
}
