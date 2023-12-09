using MediatR;

namespace ECommerceApp.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<UpdateCategoryCommandResponse>
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
    }
}
