﻿using ECommerceApp.Application.Features.Products.Commands.CreateProduct;
using ECommerceApp.Application.Features.Products.Commands.DeleteProduct;
using ECommerceApp.Application.Features.Products.Queries.GetById;
using ECommerceApp.Application.Features.Products.Queries.GetAll;

using Microsoft.AspNetCore.Mvc;

namespace ECommerceAppAPI.Controllers
{
    public class ProductsController : ApiControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetAllProducts());
            return Ok(result);
        }

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

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await Mediator.Send(new GetByIdProduct(id));
            return Ok(result);
        }
    }
}
