using ECommerceApp.Application.Models.Identity;

namespace ECommerceApp.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<(int, string)> Registration(RegistrationModel model, string role);

        Task<(int, string)> Login(LoginModel model);
        Task<(int, string)> Logout();
    }
}
