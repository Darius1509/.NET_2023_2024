using ECommerceApp.Application.Features.Addresses.Queries.GetById;
using ECommerceApp.Application.Features.Categories.Commands.CreateCategory;
using ECommerceApp.Application.Features.Categories.Commands.DeleteCategory;
using ECommerceApp.Application.Features.Categories.Commands.UpdateCategory;
using ECommerceApp.Application.Features.Categories.Queries.GetAllCategories;
using ECommerceApp.Application.Features.Categories.Queries.GetByIdCategory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAppAPI.Controllers
{
    public class CategoriesController : ApiControllerBase
    {
        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetAllCategoriesQuery());
            return Ok(result);
        }

        [Authorize(Roles = "Admin,User")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await Mediator.Send(new GetByIdCategoryQuery(id));
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateCategoryCommand createCategoryCommand)
        {
            var result = await Mediator.Send(createCategoryCommand);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(DeleteCategoryCommand deleteCategoryCommand)
        {
            var result = await Mediator.Send(deleteCategoryCommand);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<IActionResult> Update(UpdateCategoryCommand updateCategoryCommand)
        {
            var result = await Mediator.Send(updateCategoryCommand);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
