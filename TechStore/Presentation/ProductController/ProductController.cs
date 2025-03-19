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

        [HttpGet(nameof(GetProductById))]
        public IActionResult GetProductById(int _id)
        {
            BaseResponse<ProductDto> obj = customService.Get(_id);
            if (obj.Status == true) return Ok(obj);
            else return BadRequest(obj);
        }

        [HttpPut(nameof(ChangeStateProduct))]
        public IActionResult ChangeStateProduct(int _id)
        {
            BaseResponse<ProductDto> obj = customService.ChangeState(_id);
            if (obj.Status == true) return Ok(obj);
            else return BadRequest(obj);
        }

        [HttpPost(nameof(CreateProduct))]
        public IActionResult CreateProduct(ProductCreateRequest _Product)
        {
            var Product = new Product();
            BaseResponse<ProductDto> obj = customService.Insert(_Product);
            if (obj.Status == true) return Ok(obj);
            else return BadRequest(obj);
        }

        [HttpDelete(nameof(DeleteProduct))]
        public IActionResult DeleteProduct(int _id)
        {
            BaseResponse<ProductDto> obj = customService.Remove(_id);
            if (obj.Status == true) return Ok(obj);
            else return BadRequest(obj);
        }

        [HttpPut(nameof(UpdateProduct))]
        public IActionResult UpdateProduct(ProductUpdateRequest _Product)
        {
            BaseResponse<ProductDto> obj = customService.Update(_Product);
            if (obj.Status == true) return Ok(obj);
            else return BadRequest(obj);
        }
    }
}
