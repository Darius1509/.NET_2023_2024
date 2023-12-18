using MediatR;
using ECommerceApp.Application.Persistence;
using ECommerceApp.Domain.Entities;

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
                var category = Category.Update(request.Id, request.Name);
                if (category.IsSuccess)
                {
                    await repository.UpdateAsync(category.Value);
                    response.Category = new UpdateCategoryDto
                    {
                        Id = category.Value.CategoryId,
                        Name = category.Value.CategoryName
                    };
                }
                else
                {
                    response.Success = false;
                    response.ValidationsErrors = new List<string>()
                    {
                        category.ErrorMessage
                    };
                }   
            }
            return response;
        }
    }
}
