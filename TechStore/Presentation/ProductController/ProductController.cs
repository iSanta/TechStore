using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static TechStore.Application.ICustomService.ICustomService;
using TechStore.Domain.Data;
using TechStore.Domain.Models;
using TechStore.Domain.Entities;
using TechStore.Domain.Models.DTO;

namespace TechStore.Presentation.ProductController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ICustomService<ProductDto> customService;
        private readonly DataContext applicationDbContext;

        public ProductController(ICustomService<ProductDto> _customService, DataContext _applicationDbContext)
        {
            customService = _customService;
            applicationDbContext = _applicationDbContext;
        }

        [HttpGet(nameof(GetAllProducts))]
        public IActionResult GetAllProducts()
        {
            BaseResponse<IEnumerable<ProductDto>> obj = customService.GetAll();
            if (obj.Status == true) return Ok(obj);
            else return BadRequest(obj);
        }
    }
}
