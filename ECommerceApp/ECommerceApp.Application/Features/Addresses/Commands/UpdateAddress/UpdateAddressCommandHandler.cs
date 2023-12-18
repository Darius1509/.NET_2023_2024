using ECommerceApp.Application.Persistence;
using ECommerceApp.Domain.Entities;
using MediatR;

namespace ECommerceApp.Application.Features.Addresses.Commands.UpdateAddress
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, UpdateAddressCommandResponse>
    {
        private readonly IAddressRepository repository;

        public UpdateAddressCommandHandler(IAddressRepository repository)
        {
            this.repository = repository;
        }

        public async Task<UpdateAddressCommandResponse> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateAddressCommandResponse();
            var validator = new UpdateAddressCommandValidator();
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
                var address = Address.Update(request.Id, request.StreetName, request.PostalCode, request.City, request.Country);
                if (address.IsSuccess)
                {
                    await repository.UpdateAsync(address.Value);
                    response.Address = new UpdateAddressDto
                    {
                        Id = address.Value.AddressId,
                        StreetName = address.Value.StreetName,
                        PostalCode = address.Value.PostalCode,
                        City = address.Value.City,
                        Country = address.Value.Country
                    };
                }
                else
                {
                    response.Success = false;
                    response.ValidationsErrors = new List<string>()
                    {
                        address.ErrorMessage
                    };
                }
            }
            return response;
        }
    }
}
