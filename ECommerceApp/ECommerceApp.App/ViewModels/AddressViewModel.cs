using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.App.ViewModels
{
    public class AddressViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Street name is required")]
        public string StreetName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Postal code is required")]
        public int PostalCode { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; } = string.Empty;
        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; } = string.Empty;
    }
}
