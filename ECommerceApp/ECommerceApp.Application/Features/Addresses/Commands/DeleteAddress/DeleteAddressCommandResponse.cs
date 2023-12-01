using ECommerceApp.Application.Responses;

namespace ECommerceApp.Application.Features.Addresses.Commands.DeleteAddress
{
    public class DeleteAddressCommandResponse : BaseResponse
    {
        public DeleteAddressCommandResponse() : base()
        {

        }
        public DeleteAddressDto Address { get; set; }
    }
}
