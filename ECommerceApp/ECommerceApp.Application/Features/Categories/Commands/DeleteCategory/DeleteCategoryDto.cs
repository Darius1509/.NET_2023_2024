namespace ECommerceApp.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryDto
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}