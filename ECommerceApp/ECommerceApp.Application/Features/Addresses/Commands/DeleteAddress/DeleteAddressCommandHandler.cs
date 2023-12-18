using ECommerceApp.Application.Persistence;
using MediatR;

namespace ECommerceApp.Application.Features.Addresses.Commands.DeleteAddress
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, DeleteAddressCommandResponse>
    {
        private readonly IAddressRepository repository;

        public DeleteAddressCommandHandler(IAddressRepository repository)
        {
            this.repository = repository;
        }
        public async Task<DeleteAddressCommandResponse> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteAddressCommandResponse();
            var address = await repository.DeleteAsync(request.Id);

            if (!address.IsSuccess)
            {
                response.Success = false;
                response.Message = "Deletion was unsuccessful.";

                return response;
            }

            response.Success = true;
            response.Address = new DeleteAddressDto
            {
                Id = address.Value.AddressId,
                StreetName = address.Value.StreetName,
                PostalCode = address.Value.PostalCode,
                City = address.Value.City,
                Country = address.Value.Country
            };

            return response;
        }
    }

}
