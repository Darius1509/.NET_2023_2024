using ECommerceApp.Application.Features.Products.Commands.CreateProduct;
using ECommerceApp.Application.Features.Products.Commands.DeleteProduct;
using ECommerceApp.Application.Features.Products.Queries.GetById;
using ECommerceApp.Application.Features.Products.Queries.GetAll;

using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Application.Features.Products.Commands.UpdateProduct;
using Microsoft.AspNetCore.Authorization;

namespace ECommerceAppAPI.Controllers
{
    public class ProductsController : ApiControllerBase
    {
        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetAllProductsQuery());
            return Ok(result);
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await Mediator.Send(new GetByIdProductQuery(id));
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            var result = await Mediator.Send(command);
            if(!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(DeleteProductCommand command)
        {
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<IActionResult> Update(UpdateProductCommand command)
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
