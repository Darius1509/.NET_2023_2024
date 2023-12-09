using ECommerceApp.App.ViewModels;

namespace ECommerceApp.App.Contracts
{
    public interface IAuthenticationService
    {
        Task Login(LoginViewModel loginRequest);
        Task Logout();
    }
}
