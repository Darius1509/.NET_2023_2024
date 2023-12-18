using MediatR;
using ECommerceApp.Application.Persistence;

namespace ECommerceApp.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, DeleteCategoryCommandResponse>
    {
        private readonly ICategoryRepository repository;

        public DeleteCategoryCommandHandler(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteCategoryCommandResponse();
            var category = await repository.FindByIdAsync(request.CategoryId);

            if (!category.IsSuccess)
            {
                response.Success= false;
                response.Message = "Category was not deleted successfully";

                return response;
            }
            response.Success = true;
            response.Category = new DeleteCategoryDto
            {
                Id = category.Value.CategoryId,
                Name = category.Value.CategoryName
            };
            return response;
        }
    }
}
