using InventoryManamegent.Application.DTOs;
using InventoryManamegent.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManamegent.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAll(
            [FromQuery] int? pageNumber,
            [FromQuery] int? pageSize,
            [FromQuery] string? description,
            [FromQuery] bool? asset,
            [FromQuery] int? companyId)
        {
            try
            {
                var products = await _productService.GetProducts(
                    pageNumber,
                    pageSize,
                    description,
                    asset,
                    companyId);

                if (products == null || !products.Any())
                    return NotFound(new { Message = "Products not found." });

                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetById([FromRoute] int id)
        {
            try
            {
                var produto = await _productService.GetById(id);
                if (produto == null)
                    return NotFound(new { Message = "Products not found." });

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDTO produtoDto)
        {
            try
            {
                await _productService.Add(produtoDto);

                return Ok(new { Message = "Registered successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductDTO produtoDto)
        {
            try
            {
                if (produtoDto == null || produtoDto.Id != id)
                    return BadRequest(new { Message = "Invalid data or ID mismatch." });

                var produtoExist = await _productService.GetById(id);

                if (produtoExist == null)
                    return NotFound(new { Message = "Product not found." });

                await _productService.Update(produtoDto);

                return Ok(new { Message = "Edited successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ErrorMessage = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductDTO>> Delete([FromRoute] int id)
        {
            try
            {
                var produtoDto = await _productService.GetById(id);

                if (produtoDto == null)
                    return NotFound("Product not found.");

                await _productService.Remove(id);

                return Ok(new { Message = "Successfully deleted." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
    }
}
