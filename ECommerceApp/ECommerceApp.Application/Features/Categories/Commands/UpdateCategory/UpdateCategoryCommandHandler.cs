using MediatR;
using ECommerceApp.Application.Persistence;

namespace ECommerceApp.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdateCategoryCommandResponse>
    {
        private readonly ICategoryRepository repository;

        public UpdateCategoryCommandHandler(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateCategoryCommandResponse();
            var validator = new UpdateCategoryCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
            {
                response.Success = false;
                response.ValidationsErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    response.ValidationsErrors.Add(error.ErrorMessage);
                }
            }
            if (response.Success)
            {
                var category = await repository.FindByIdAsync(request.CategoryId);
                if (!category.IsSuccess)
                {
                    response.Success = false;
                    response.ValidationsErrors = new List<string>()
                    {
                        "Category not found"
                    };
                }
                response.Success = true;
                response.Category = new UpdateCategoryDto
                {
                    Id = category.Value.CategoryId,
                    CategoryName = category.Value.CategoryName
                };

            }
            return response;
        }
    }
}
