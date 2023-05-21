using CoreWebApiAngularCapstoneProject.DAL;
using CoreWebApiAngularCapstoneProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebApiAngularCapstoneProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        [HttpGet("getcategorylist")]
        public async Task<List<Category>> GetCategoriesAsync()
        {
            try
            {
                return await categoryService.GetCategoryListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("getcategorybyid")]
        public async Task<IEnumerable<Category>> GetCategoriesByIdAsync(int CategoryId)
        {
            try
            {
                var response = await categoryService.GetCategoryByIdAsync(CategoryId);
                if (response == null)
                {
                    return null;
                }
                return response;
            }
            catch
            {
                throw;
            }
        }

        [HttpPost("addcategory")]

        public async Task<IActionResult> AddCategory(Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }
            try
            {
                var response = await categoryService.AddCategoryAsync(category);

                return Ok(response);
            }
            catch
            {
                throw;
            }
        }

        [HttpPut("updatecategory")]

        public async Task<IActionResult> UpdateCategory(int CategoryId, Category category)
        {
            if (category == null && CategoryId < 0)
            {
                return BadRequest();
            }
            try
            {
                var response = await categoryService.UpdateCategoryAsync(CategoryId, category);

                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpDelete("deletecategorybyid")]

        public async Task<IActionResult> DeleteCategory(int CategoryId)
        {
            if (CategoryId == null)
            {
                return BadRequest();
            }
            try
            {
                var response = await categoryService.DeleteCategoryAsync(CategoryId);
                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
