using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingBackend.Dtos.Product;
using OnlineShoppingBackend.Models;
using OnlineShoppingBackend.Services.ProductService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingBackend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [AllowAnonymous]
        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            return Ok(await _productService.GetAllProduct());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _productService.GetProductById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductDto newProduct)
        {
            return Ok(await _productService.AddProduct(newProduct));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCharacter(UpdateProductDto updatedProduct)
        {
            ServiceResponse<GetProductDto> response = await _productService.UpdateProduct(updatedProduct);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponse<List<GetProductDto>> response = await _productService.DeleteProduct(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

    }
}
