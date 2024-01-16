using FluentValidation;

namespace ECommerceApp.Application.Features.Orders.Commands.AddProductsToOrder
{
    public class AddProductToOrderCommandValidator : AbstractValidator<AddProductToOrderCommand>
    {
        public AddProductToOrderCommandValidator()
        {
            RuleFor(p => p.Date)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
            RuleFor(p => p.OrderCustomerId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
            RuleFor(p => p.OrderStatus)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
