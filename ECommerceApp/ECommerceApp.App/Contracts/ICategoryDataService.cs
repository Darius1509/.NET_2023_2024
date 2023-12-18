using ECommerceApp.App.Services.Responses;
using ECommerceApp.App.ViewModels;

namespace ECommerceApp.App.Contracts
{
    public interface ICategoryDataService
    {
        Task<List<CategoryViewModel>> GetCategoriesAsync();

        Task<CategoryViewModel> GetCategoryByIdAsync(Guid id);

        Task<ApiResponse<CategoryDto>> UpdateCategoryAsync(CategoryViewModel categoryViewModel);

        Task<ApiResponse<CategoryDto>> CreateCategoryAsync(CategoryViewModel categoryViewModel);
    }
}
