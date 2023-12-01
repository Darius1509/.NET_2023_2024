using MediatR;

namespace ECommerceApp.Application.Features.Addresses.Commands.DeleteAddress
{
    public class DeleteAddressCommand : IRequest<DeleteAddressCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
