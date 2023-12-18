using ECommerceApp.App.Services.Responses;
using ECommerceApp.App.ViewModels;

namespace ECommerceApp.App.Contracts
{
    public interface IAddressDataService
    {
        Task<List<AddressViewModel>> GetAddressesAsync();

        Task<AddressViewModel> GetAddressByIdAsync(Guid id);

        Task<ApiResponse<AddressDto>> UpdateAddressAsync(AddressViewModel addressViewModel);

        Task<ApiResponse<AddressDto>> CreateAddressAsync(AddressViewModel addressViewModel);
    }
}
