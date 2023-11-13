using MediatR;

namespace ECommerceApp.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<DeleteProductCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
