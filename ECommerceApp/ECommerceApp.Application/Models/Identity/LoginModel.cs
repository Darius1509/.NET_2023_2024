using System.ComponentModel.DataAnnotations;

namespace ECommerceApp.Application.Models.Identity
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User StreetName is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
