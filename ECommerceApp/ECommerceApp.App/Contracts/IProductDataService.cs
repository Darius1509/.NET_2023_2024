using ECommerceApp.App.Services.Responses;
using ECommerceApp.App.ViewModels;

namespace ECommerceApp.App.Contracts
{
    public interface IProductDataService
    {
        Task<List<ProductViewModel>> GetProductsAsync();

        Task<ApiResponse<ProductDto>> CreateProductAsync(ProductViewModel productViewModel);
    }
}
