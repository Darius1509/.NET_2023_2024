﻿using FluentValidation;

namespace ECommerceApp.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
           RuleFor(c => c.Id)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull();
    
                RuleFor(c => c.Name)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull()
                    .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        }
    }
}
