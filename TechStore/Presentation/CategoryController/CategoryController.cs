using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechStore.Application.ICustomService;
using TechStore.Core.Entities;
using TechStore.Domain.Data;
using TechStore.Domain.Entities;
using TechStore.Domain.Models.DTO;
using static TechStore.Application.ICustomService.ICustomService;

namespace TechStore.Presentation.CategoryController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICustomService<CategoryDto> customService;
        private readonly DataContext applicationDbContext;
        public CategoryController(ICustomService<CategoryDto> _customService, DataContext _applicationDbContext)
        {
            customService = _customService;
            applicationDbContext = _applicationDbContext;
        }

        [HttpGet(nameof(GetCategoryById))]
        public IActionResult GetCategoryById(int _id)
        {
            BaseResponse<CategoryDto> obj = customService.Get(_id);
            if(obj.Status == true) return Ok(obj);
            else return BadRequest(obj);
        }

        [HttpGet(nameof(GetAllCategories))]
        public IActionResult GetAllCategories()
        {
            BaseResponse<IEnumerable<CategoryDto>> obj = customService.GetAll();
            if (obj.Status == true) return Ok(obj);
            else return BadRequest(obj);
        }

        [HttpPost(nameof(CreateCategory))]
        public IActionResult CreateCategory(CategoryCreateRequest _category)
        {
            var category = new Category();
            BaseResponse<CategoryDto> obj = customService.Insert(_category);
            if (obj.Status == true) return Ok(obj);
            else return BadRequest(obj);
        }

        [HttpPut(nameof(UpdateCategory))]
        public IActionResult UpdateCategory(CategoryUpdateRequest _category)
        {
            BaseResponse<CategoryDto> obj = customService.Update(_category);
            if (obj.Status == true) return Ok(obj);
            else return BadRequest(obj);
        }

        [HttpPut(nameof(ChangeStateCategory))]
        public IActionResult ChangeStateCategory(int _id)
        {
            BaseResponse<CategoryDto> obj = customService.ChangeState(_id);
            if (obj.Status == true) return Ok(obj);
            else return BadRequest(obj);
        }

        [HttpDelete(nameof(DeleteCategory))]
        public IActionResult DeleteCategory(int _id)
        {
            BaseResponse<CategoryDto> obj = customService.Remove(_id);
            if (obj.Status == true) return Ok(obj);
            else return BadRequest(obj);
        }
    }
}
