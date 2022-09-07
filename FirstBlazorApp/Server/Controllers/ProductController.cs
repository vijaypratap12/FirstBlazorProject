using FirstBlazorApp.Server.DAL.Interfaces;
using FirstBlazorApp.Server.Model;
using FirstBlazorApp.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstBlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _product;
            private readonly IConfiguration _configuration;
        public ProductController(IProductRepo product, IConfiguration configuration)
        {
            _product = product; 
            _configuration = configuration; 
        }

        [HttpGet, Route("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            Products products = new Products();
            var res = await _product.GetProduct();
            try
            {
                if (res == null)
                {
                    return BadRequest(new { error = "Invalid request." });
                }
                return Ok(res);

            }
            catch(Exception ex)
            {
                return BadRequest(new { error = $"{ex.Message} {ex.InnerException} {ex.StackTrace}" });
            }
        }

        [HttpPost, Route("AddUpdateProduct")]
        public async Task<IActionResult> AddProduct(Products products)
        {
            var res = await _product.AddProduct(products);
            try
            {
                if (res == null)
                {
                    return BadRequest(new { error = "Invalid request." });
                }
                return Ok(res);
            }
            catch(Exception ex)
            {
                return BadRequest(new { error = $"{ex.Message} {ex.InnerException} {ex.StackTrace}" });
            }
           
        }

        [HttpPost, Route("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(Int64 productId)
        {
            var res = await _product.DeleteProduct(productId);
            try
            {
                if (res == null)
                {
                    return BadRequest(new { error = "Invalid request." });
                }
                return Ok(res);
            }
            catch(Exception ex)
            {
                return BadRequest(new { error = $"{ex.Message} {ex.InnerException} {ex.StackTrace}" });
            }
            
        }

       
    }
}
