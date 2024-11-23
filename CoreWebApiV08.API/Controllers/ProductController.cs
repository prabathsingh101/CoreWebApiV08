using CoreWebApiV08.API.Models.Products;
using CoreWebApiV08.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebApiV08.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProducts _products;
        public ProductController(IProducts products)
        {
            _products = products;
        }
        [HttpGet]
        [Route("GetAll")]
        [Produces("application/json")]
        public async Task<IActionResult> Get()
        {

            var model = await _products.GetProductsAsync();
            if (model == null)
                return NotFound();
            return Ok(model);
        }
        [HttpGet]
        [Route("{id:int}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var model = await _products.GetProductsByIdAsync(id);

            if (model == null)
                return NotFound();
            return Ok(model);
        }

        [HttpPost]
        [Route("Create")]
        [Produces("application/json")]
        public async Task<IActionResult> Post([FromBody] Products products)
        {
            var model = await _products.AddProductAsync(products);

            if (model == null)
                return BadRequest();
            return Ok(model);
        }

        [HttpPut]
        [Route("{id:int}")]
        [Produces("application/json")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Products products)
        {
            var model = await _products.UpdateProductAsync(id, products);

            if (model == null)
                return BadRequest();
            return Ok(model);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Produces("application/json")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var model = await _products.DeleteProductAsync(id);

            if (model == null)
                return BadRequest();
            return Ok(model);
        }
    }
}
