using FirstBlazorApp.Server.DAL.Interfaces;
using FirstBlazorApp.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstBlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepo _category;
        public CategoryController(ICategoryRepo category)
        {
            _category = category;
        }

        [HttpGet, Route("GetCategory")]
        public async Task<IActionResult> GetCategory()
        {
            Category category = new Category();
            var res = await _category.GetCategory();
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
        [HttpPost, Route("AddUpdateCategory")]
        public async Task<IActionResult> AddUpdateCategory(Category category)
        {
            var res = _category.AddUpdateCategory(category);
            try
            {
                if (res == null)
                {
                    return BadRequest(new { error = "Invalid request." });
                }
                return Ok(res.Status);
            }
            catch(Exception ex)
            {
                return BadRequest(new { error = $"{ex.Message} {ex.InnerException} {ex.StackTrace}" });
            }
        }

    }
}
