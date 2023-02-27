using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebMediatRExample.Models;
using WebMediatRExample.Models.Command;
using WebMediatRExample.Models.Queries;
using WebMediatRExample.Notifications;

namespace WebMediatRExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());

            return Ok(products);
        }
        [HttpGet("{id:int}",Name = "GetProductById")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var products = await _mediator.Send(new GetProductByIdQuery(id));

            return Ok(products);
        }
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if(product is null)
            {
                return BadRequest();
            }
            var result = await _mediator.Send(new AddProductCommand(product));

            await _mediator.Publish(new ProductAddedNotification(result));

            return CreatedAtRoute("GetProductById", new { id = result.Id }, result);
        }
        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            if (product is null)
            {
                return BadRequest();
            }
            var result = await _mediator.Send(new UpdateProductCommand(product));
            return Ok(result);
        }
        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (id is 0)
            {
                return BadRequest();
            }
            var result = await _mediator.Send(new DeleteProductCommand(id));
            return Ok(result);
        }
    }
}
