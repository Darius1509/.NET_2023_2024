using ECommerceApp.Application.Contracts;
using ECommerceApp.Domain.Entities;
using MediatR;

namespace ECommerceApp.Application.Features.Addresses.Commands.CreateAddress
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, CreateAddressCommandResponse>
    {
        private readonly IAddressRepository repository;

        public CreateAddressCommandHandler(IAddressRepository repository)
        {
            this.repository = repository;
        }

        public async Task<CreateAddressCommandResponse> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateAddressCommandResponse();
            var validator = new CreateAddressCommandValidator();
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
                var address = Address.Create(request.StreetName, request.PostalCode, request.City, request.Country);
                if (address.IsSuccess)
                {
                    await repository.AddAsync(address.Value);
                    response.Address = new CreateAddressDto
                    {
                        AddressId = address.Value.AddressId,
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
