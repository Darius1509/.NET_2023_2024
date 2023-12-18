using ECommerceApp.App.Services.Responses;
using ECommerceApp.App.ViewModels;

namespace ECommerceApp.App.Contracts
{
    public interface IProductDataService
    {
        Task<List<ProductViewModel>> GetProductsAsync();

        Task<ProductViewModel> GetProductByIdAsync(Guid id);

        Task<ApiResponse<ProductDto>> CreateProductAsync(ProductViewModel productViewModel);

        Task<ApiResponse<ProductDto>> UpdateProductAsync(ProductViewModel productViewModel);
    }
}
