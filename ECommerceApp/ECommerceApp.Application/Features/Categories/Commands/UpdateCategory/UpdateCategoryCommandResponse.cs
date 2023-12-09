using ECommerceApp.Application.Responses;

namespace ECommerceApp.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandResponse : BaseResponse
    {
        public UpdateCategoryCommandResponse() : base()
        {
        }

        public UpdateCategoryDto Category { get; set; }
    }
}
