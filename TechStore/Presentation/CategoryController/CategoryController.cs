using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechStore.Application.ICustomService;
using TechStore.Core.Entities;
using TechStore.Domain.Data;
using static TechStore.Application.ICustomService.ICustomService;

namespace TechStore.Presentation.CategoryController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICustomService<Category> customService;
        private readonly DataContext applicationDbContext;
        public CategoryController(ICustomService<Category> _customService, DataContext _applicationDbContext)
        {
            customService = _customService;
            applicationDbContext = _applicationDbContext;
        }

        [HttpGet(nameof(GetCategoryById))]
        public IActionResult GetCategoryById(int Id)
        {
            var obj = customService.Get(Id);
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(obj);
            }
        }

        [HttpGet(nameof(GetAllCategories))]
        public IActionResult GetAllCategories()
        {
            var obj = customService.GetAll();
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(obj);
            }
        }

        [HttpPost(nameof(CreateCategory))]
        public IActionResult CreateCategory(Category category)
        {
            if (category != null)
            {
                customService.Insert(category);
                return Ok("Created Successfully");
            }
            else
            {
                return BadRequest("Somethingwent wrong");
            }
        }

        [HttpPut(nameof(UpdateCategory))]
        public IActionResult UpdateCategory(Category category)
        {
            if (category != null)
            {
                customService.Update(category);
                return Ok("Updated SuccessFully");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete(nameof(DeleteCategory))]
        public IActionResult DeleteCategory(Category category)
        {
            if (category != null)
            {
                customService.Delete(category);
                return Ok("Deleted Successfully");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }
    }
}
