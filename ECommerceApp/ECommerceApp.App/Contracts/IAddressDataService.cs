using ECommerceApp.App.Services.Responses;
using ECommerceApp.App.ViewModels;

namespace ECommerceApp.App.Contracts
{
    public interface IAddressDataService
    {
        Task<List<AddressViewModel>> GetAddressesAsync();

        Task<ApiResponse<AddressDto>> CreateAddressAsync(AddressViewModel addressViewModel);
    }
}
