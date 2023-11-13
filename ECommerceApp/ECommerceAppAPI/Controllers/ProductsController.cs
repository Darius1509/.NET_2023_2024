using ECommerceApp.Application.Features.Products.Commands.CreateProduct;
using ECommerceApp.Application.Features.Products.Commands.DeleteProduct;
using ECommerceApp.Application.Features.Products.Queries.GetById;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAppAPI.Controllers
{
    public class ProductsController : ApiControllerBase
    {
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

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(DeleteProductCommand command)
        {
            var result = await Mediator.Send(command);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        //make it so that i can input a string instead of a guid

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await Mediator.Send(new GetByIdProduct(id));
            return Ok(result);
        }
    }
}
