using ECommerceApp.Application.Features.Orders.Commands.AddProductsToOrder;
using ECommerceApp.Application.Features.Orders.Commands.CreateOrder;
using ECommerceApp.Application.Features.Orders.Commands.DeleteOrder;
using ECommerceApp.Application.Features.Orders.Commands.UpdateOrder;
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

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(DeleteOrderCommand deleteOrderCommand)
        {
            var result = await Mediator.Send(deleteOrderCommand);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<IActionResult> Update(UpdateOrderCommand updateOrderCommand)
        {
            var result = await Mediator.Send(updateOrderCommand);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpPost("{orderId}/attach-product")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AttachProduct(Guid orderId, [FromBody] AddProductToOrderCommand attachProductCommand)
        {
            try
            {
                attachProductCommand.Id = orderId;
                var result = await Mediator.Send(attachProductCommand);

                if (!result.Success)
                {
                    return BadRequest(result);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
