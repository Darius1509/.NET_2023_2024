using ECommerceApp.Application.Features.Addresses.Commands.CreateAddress;
using ECommerceApp.Application.Features.Addresses.Commands.DeleteAddress;
using ECommerceApp.Application.Features.Addresses.Queries.GetById;
using ECommerceApp.Application.Features.Addresses.Queries.GetAll;
using ECommerceApp.Application.Features.Addresses.Commands.UpdateAddress;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ECommerceAppAPI.Controllers
{
    public class AddressesController : ApiControllerBase
    {
        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetAllAddressesQuery());
            return Ok(result);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await Mediator.Send(new GetByIdAddressQuery(id));
            return Ok(result);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateAddressCommand command)
        {
            var result = await Mediator.Send(command);
            if(!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(DeleteAddressCommand command)
        {
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<IActionResult> Update(UpdateAddressCommand command)
        {
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}