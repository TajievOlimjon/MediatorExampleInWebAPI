using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebMediatRExample.Models.Command;
using WebMediatRExample.Models.Queries;

namespace WebMediatRExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            var products = await _mediator.Send(new GetAllCategoryQuery());

            return Ok(products);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(AddCategoryCommand addCategoryCommand)
        {
            var result = await _mediator.Send(addCategoryCommand);
            return Ok(result);
        }
    }
}
