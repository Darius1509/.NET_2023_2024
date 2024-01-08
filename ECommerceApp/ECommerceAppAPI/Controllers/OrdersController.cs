using ECommerceApp.Application.Features.Orders.Commands.CreateOrder;
using ECommerceApp.Application.Features.Orders.Queries.GetAllOrders;
using ECommerceApp.Application.Features.Orders.Queries.GetByIdOrder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAppAPI.Controllers
{
    public class OrdersController : ApiControllerBase
    {
        [Authorize(Roles = "Admin, User")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateOrderCommand createOrderCommand)
        {
            var result = await Mediator.Send(createOrderCommand);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetAllOrdersQuery());
            return Ok(result);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await Mediator.Send(new GetByIdOrderQuery(id));
            return Ok(result);
        }
    }
}
