using CoreWebApiV08.API.Data;
using CoreWebApiV08.API.Models.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace CoreWebApiV08.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IDistributedCache _cache;
        public ProductsController(DatabaseContext context, IDistributedCache cache)
        {
            _context = context;
            _cache = cache;
        }
        [HttpGet("all")]
        [Produces("application/json")]
        public async Task<IActionResult> GetAll()
        {
            var cacheKey = "GET_ALL_PRODUCTS";
            List<Products> products;
            try
            {
                // Get data from cache
                var cachedData = await _cache.GetStringAsync(cacheKey);
                if (cachedData != null)
                {
                    // Deserialize cached data
                    products = JsonSerializer.Deserialize<List<Products>>(cachedData) ?? new List<Products>();
                }
                else
                {
                    // Fetch data from database
                    products = await _context.TblProducts.AsNoTracking().ToListAsync();
                    if (products != null)
                    {
                        // Serialize data and cache it
                        var serializedData = JsonSerializer.Serialize(products);
                        var cacheOptions = new DistributedCacheEntryOptions()
                            .SetSlidingExpiration(TimeSpan.FromMinutes(5));
                        await _cache.SetStringAsync(cacheKey, serializedData, cacheOptions);
                    }
                }
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving products.", details = ex.Message });
            }
        }

        [HttpGet("Category")]
        [Produces("application/json")]
        public async Task<IActionResult> GetProductByCategory(string Category)
        {
            var cacheKey = $"PRODUCTS_{Category}";
            List<Products> products;
            try
            {
                // Get data from cache
                var cachedData = await _cache.GetStringAsync(cacheKey);
                if (cachedData != null)
                {
                    // Deserialize cached data
                    products = JsonSerializer.Deserialize<List<Products>>(cachedData) ?? new List<Products>();
                }
                else
                {
                    // Fetch data from database
                    products = await _context.TblProducts.Where(prd => prd.Category.ToLower() == Category.ToLower()).AsNoTracking().ToListAsync();
                    if (products != null)
                    {
                        // Serialize data and cache it
                        var serializedData = JsonSerializer.Serialize(products);
                        var cacheOptions = new DistributedCacheEntryOptions()
                            .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
                        await _cache.SetStringAsync(cacheKey, serializedData, cacheOptions);
                    }
                }
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving products.", details = ex.Message });
            }
        }

        // GET: api/products/{id}
        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var cacheKey = $"Product_{id}";
            Products? product;
            try
            {
                // Attempt to retrieve data from cache
                var cachedData = await _cache.GetStringAsync(cacheKey);
                if (!string.IsNullOrEmpty(cachedData))
                {
                    product = JsonSerializer.Deserialize<Products>(cachedData) ?? new Products();
                }
                else
                {
                    // Fetch data from database if not found in cache
                    product = await _context.TblProducts.FindAsync(id);
                    if (product == null)
                        return NotFound($"Product with ID {id} not found.");
                    // Cache the product data
                    var serializedData = JsonSerializer.Serialize(product);
                    //var cacheOprions = new DistributedCacheEntryOptions
                    //{
                    //    SlidingExpiration = TimeSpan.FromMinutes(5)
                    //};
                    await _cache.SetStringAsync(cacheKey, serializedData, new DistributedCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromMinutes(5)
                    });
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving the product.", details = ex.Message });
            }
        }

        // PUT: api/products/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Products updatedProduct)
        {
            if (id != updatedProduct.id)
            {
                return BadRequest("Product ID mismatch.");
            }
            try
            {
                var existingProduct = await _context.TblProducts.FindAsync(id);
                if (existingProduct == null)
                    return NotFound($"Product with ID {id} not found.");
                // Update product in database
                _context.Entry(existingProduct).CurrentValues.SetValues(updatedProduct);
                //existingProduct.Name = updatedProduct.Name;
                //existingProduct.Price = updatedProduct.Price;
                //existingProduct.Category = updatedProduct.Category;
                //existingProduct.Quantity = updatedProduct.Quantity;
                await _context.SaveChangesAsync();
                // Update product in cache
                var cacheKey = $"Product_{id}";
                var serializedData = JsonSerializer.Serialize(updatedProduct);
                await _cache.SetStringAsync(cacheKey, serializedData, new DistributedCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromMinutes(5)
                });
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while updating the product.", details = ex.Message });
            }
        }


        // DELETE: api/products/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var product = await _context.TblProducts.FindAsync(id);
                if (product == null)
                    return NotFound($"Product with ID {id} not found.");
                // Delete product from database
                _context.TblProducts.Remove(product);
                await _context.SaveChangesAsync();
                // Remove product from cache
                var cacheKey = $"Product_{id}";
                await _cache.RemoveAsync(cacheKey);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while deleting the product.", details = ex.Message });
            }
        }
    }
}
