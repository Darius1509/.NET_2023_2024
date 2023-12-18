using MediatR;
using ECommerceApp.Application.Persistence;
using ECommerceApp.Domain.Entities;

namespace ECommerceApp.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
    {
        private readonly ICategoryRepository repository;

        public CreateCategoryCommandHandler(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
			var response = new CreateCategoryCommandResponse();
            var validator = new CreateCategoryCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
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
                var category = Category.Create(request.Name);
                if (category.IsSuccess)
                {
                    await repository.AddAsync(category.Value);
                    response.Category = new CreateCategoryDto
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
