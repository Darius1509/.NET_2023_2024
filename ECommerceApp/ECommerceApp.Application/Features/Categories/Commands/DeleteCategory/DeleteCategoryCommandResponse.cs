using ECommerceApp.Application.Responses;

namespace ECommerceApp.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandResponse : BaseResponse
    {
        public DeleteCategoryCommandResponse() : base()
        {
        }

        public DeleteCategoryDto Category { get; set; }
    }
}
