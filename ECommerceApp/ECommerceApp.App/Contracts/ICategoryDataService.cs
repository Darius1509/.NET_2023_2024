using ECommerceApp.App.Services.Responses;
using ECommerceApp.App.ViewModels;

namespace ECommerceApp.App.Contracts
{
    public interface ICategoryDataService
    {
        Task<List<CategoryViewModel>> GetCategoriesAsync();

        Task<ApiResponse<CategoryDto>> CreateCategoryAsync(CategoryViewModel categoryViewModel);
    }
}
