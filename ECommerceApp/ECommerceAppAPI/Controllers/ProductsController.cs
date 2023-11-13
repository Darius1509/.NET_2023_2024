using ECommerceApp.Application.Features.Products.Commands.CreateProduct;
using ECommerceApp.Application.Features.Products.Commands.DeleteProduct;
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

        public async Task<IActionResult> Delete(DeleteProductCommand command)
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
