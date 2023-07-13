using ArriveWarehouseManagementApi.Models;
using ArriveWarehouseManagementApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ArriveWarehouseManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService) 
        {
            _productService = productService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _productService.GetAllAsync();
            return Ok(result.Value);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var result = await _productService.GetByIdAsync(id);
            return Ok(result.Value);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            var result = await _productService.CreateAsync(product);
            if (result.IsSuccessful) return Ok(result.Value);
            
            return BadRequest(result.Messages);
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            var result = await _productService.UpdateAsync(product);
            if (result.IsSuccessful) return Ok(result.Value);

            return BadRequest(result.Messages);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteAsync(id);
            if (result.IsSuccessful) return Ok();

            return BadRequest(result.Messages);
        }
    }
}
